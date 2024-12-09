package com.ecommerce.library.service.impl;

import com.ecommerce.library.dto.ProductDto;
import com.ecommerce.library.dto.ShoppingCartDto;
import com.ecommerce.library.model.CartItem;
import com.ecommerce.library.model.Customer;
import com.ecommerce.library.model.Product;
import com.ecommerce.library.model.ShoppingCart;
import com.ecommerce.library.repository.CartItemRepository;
import com.ecommerce.library.repository.ShoppingCartRepository;
import com.ecommerce.library.service.CustomerService;
import com.ecommerce.library.service.ShoppingCartService;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.ObjectUtils;

import java.util.ArrayList;
import java.util.List;

@Service
public class ShoppingCartServiceImpl  implements ShoppingCartService {
    private final ShoppingCartRepository cartRepository;

    private final CartItemRepository itemRepository;

    private final CustomerService customerService;

    public ShoppingCartServiceImpl(ShoppingCartRepository cartRepository, CartItemRepository itemRepository, 
                                    CustomerService customerService) {
        this.cartRepository = cartRepository;
        this.itemRepository = itemRepository;
        this.customerService = customerService;
    }

    private CartItem find(List<CartItem> cartItems, long productId) {
        if (cartItems == null) {
            return null;
        }
        CartItem cartItem = null;
        for (CartItem item : cartItems) {
            if (item.getProduct().getId() == productId) {
                cartItem = item;
            }
        }
        return cartItem;
    }

    private Product transfer(ProductDto productDto) {
        Product product = new Product();
        product.setId(productDto.getId());
        product.setName(productDto.getName());
        product.setCurrentQuantity(productDto.getCurrentQuantity());
        product.setCostPrice(productDto.getCostPrice());
        product.setSalePrice(productDto.getSalePrice());
        product.setDescription(productDto.getDescription());
        product.setImage(productDto.getImage());
        product.setIs_activated(productDto.isIs_activated());
        product.setIs_deleted(productDto.isIs_deleted());
        product.setCategory(productDto.getCategory());
        return product;
    }

    private int totalItem(List<CartItem> cartItemList) {
        int totalItem = 0;
        for (CartItem item : cartItemList) {
            totalItem += item.getQuantity();
        }
        return totalItem;
    }

    private double totalPrice(List<CartItem> cartItemList) {
        double totalPrice = 0.0;
        for (CartItem item : cartItemList) {
            totalPrice += item.getUnitPrice() * item.getQuantity();
        }
        return totalPrice;
    }

    @Override
    @Transactional
    public ShoppingCart addItemToCart(ProductDto productDto, int quantity, String username) {
        Customer customer = customerService.findByUsername(username);
        ShoppingCart shoppingCart = customer.getCart();

        if (shoppingCart == null) {
            shoppingCart = new ShoppingCart();
        }
        List<CartItem> cartItemList = shoppingCart.getCartItems();
        CartItem cartItem = find(cartItemList, productDto.getId());
        Product product = transfer(productDto);

        double unitPrice = productDto.getCostPrice();

        int itemQuantity = 0;
        if (cartItemList == null) {
            cartItemList = new ArrayList<>();
            cartItem = new CartItem();
            cartItem.setProduct(product);
            cartItem.setQuantity(quantity);
            cartItem.setUnitPrice(unitPrice);
            cartItem.setCart(shoppingCart);
            cartItemList.add(cartItem);
            itemRepository.save(cartItem);
        } else {
            if (cartItem == null) {
                cartItem = new CartItem();
                cartItem.setProduct(product);
                cartItem.setQuantity(quantity);
                cartItem.setUnitPrice(unitPrice);
                cartItem.setCart(shoppingCart);
                cartItemList.add(cartItem);
                itemRepository.save(cartItem);
            } else {
                itemQuantity = cartItem.getQuantity() + quantity;
                cartItem.setQuantity(itemQuantity);
                itemRepository.save(cartItem);
            }
        }
        shoppingCart.setCartItems(cartItemList);

        double totalPrice = totalPrice(shoppingCart.getCartItems());
        int totalItem = totalItem(shoppingCart.getCartItems());

        shoppingCart.setTotalPrice(totalPrice);
        shoppingCart.setTotalItems(totalItem);
        shoppingCart.setCustomer(customer);

        return cartRepository.save(shoppingCart);
    }

    @Override
    @Transactional
    public ShoppingCart updateCart(ProductDto productDto, int quantity, String username) {
        Customer customer = customerService.findByUsername(username);
        ShoppingCart shoppingCart = customer.getCart();
        List<CartItem> cartItemList = shoppingCart.getCartItems();
        CartItem item = find(cartItemList, productDto.getId());

        item.setQuantity(quantity);
        itemRepository.save(item);
        shoppingCart.setCartItems(cartItemList);
        int totalItem = totalItem(cartItemList);
        double totalPrice = totalPrice(cartItemList);
        shoppingCart.setTotalPrice(totalPrice);
        shoppingCart.setTotalItems(totalItem);
        return cartRepository.save(shoppingCart);
    }

    @Override
    @Transactional(propagation = Propagation.REQUIRES_NEW)
    public ShoppingCart removeItemFromCart(ProductDto productDto, String username) {
        Customer customer = customerService.findByUsername(username);
        ShoppingCart shoppingCart = customer.getCart();
        List<CartItem> cartItemList = shoppingCart.getCartItems();
        CartItem item = find(cartItemList, productDto.getId());

        cartItemList.remove(item);
        itemRepository.delete(item);
        double totalPrice = totalPrice(cartItemList);
        int totalItem = totalItem(cartItemList);
        shoppingCart.setCartItems(cartItemList);
        shoppingCart.setTotalPrice(totalPrice);
        shoppingCart.setTotalItems(totalItem);
        return cartRepository.save(shoppingCart);
    }

    @Override
    public ShoppingCartDto addItemToCartSession(ShoppingCartDto cartDto, ProductDto productDto, int quantity) {
        return null;
    }

    @Override
    public ShoppingCartDto updateCartSession(ShoppingCartDto cartDto, ProductDto productDto, int quantity) {
        return null;
    }

    @Override
    public ShoppingCartDto removeItemFromCartSession(ShoppingCartDto cartDto, ProductDto productDto, int quantity) {
        return null;
    }

    @Override
    public ShoppingCart combineCart(ShoppingCartDto cartDto, ShoppingCart cart) {
        return null;
    }

    @Override
    public void deleteCartById(Long id) {
        ShoppingCart shoppingCart = cartRepository.getReferenceById(id);
        if(!ObjectUtils.isEmpty(shoppingCart) && !ObjectUtils.isEmpty(shoppingCart.getCartItems())){
            itemRepository.deleteAll(shoppingCart.getCartItems());
        }
        shoppingCart.getCartItems().clear();
        shoppingCart.setTotalPrice(0);
        shoppingCart.setTotalItems(0);
        cartRepository.save(shoppingCart);
    }

    @Override
    public ShoppingCart getCart(String username) {
        Customer customer = customerService.findByUsername(username);
        return customer.getCart();
    }
}
