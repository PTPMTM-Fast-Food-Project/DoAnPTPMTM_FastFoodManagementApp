package com.ecommerce.library.service.impl;

import com.ecommerce.library.model.*;
import com.ecommerce.library.repository.CartItemRepository;
import com.ecommerce.library.repository.CustomerRepository;
import com.ecommerce.library.repository.OrderDetailRepository;
import com.ecommerce.library.repository.OrderRepository;
import com.ecommerce.library.repository.ProductRepository;
import com.ecommerce.library.service.OrderService;
import com.ecommerce.library.service.ShoppingCartService;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Optional;

@Service
public class OrderServiceImpl implements OrderService {
    private final OrderRepository orderRepository;
    private final OrderDetailRepository detailRepository;
    private final CustomerRepository customerRepository;
    private final ShoppingCartService cartService;
    private final CartItemRepository cartItemRepository;
    private final ProductRepository productRepository;

    public OrderServiceImpl(OrderRepository orderRepository, OrderDetailRepository detailRepository, 
                            CustomerRepository customerRepository, ShoppingCartService cartService,
                            CartItemRepository cartItemRepository, ProductRepository productRepository) {
        this.orderRepository = orderRepository;
        this.detailRepository = detailRepository;
        this.customerRepository = customerRepository;
        this.cartService = cartService;
        this.cartItemRepository = cartItemRepository;
        this.productRepository = productRepository;
    }

    @Override
    @Transactional
    public Order save(ShoppingCart shoppingCart) {
        Order order = new Order();
        order.setOrderDate(new Date());
        order.setCustomer(shoppingCart.getCustomer());
        order.setTax(2);
        order.setAccept(false);
        order.setPaymentMethod("Cash");
        order.setOrderStatus("PENDING");
        order.setQuantity(shoppingCart.getTotalItems());

        double totalPrice = 0.0;

        List<OrderDetail> orderDetailList = new ArrayList<>();
        for (CartItem item : shoppingCart.getCartItems()) {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.setOrder(order);
            orderDetail.setProduct(item.getProduct());
            orderDetail.setQuantity(item.getQuantity());
            totalPrice += (orderDetail.getQuantity() * orderDetail.getProduct().getCostPrice());

            OrderDetail savedOrderDetail = detailRepository.save(orderDetail);
            Product product = productRepository.findById(savedOrderDetail.getProduct().getId()).get();
            product.setCurrentQuantity(product.getCurrentQuantity() - item.getQuantity());
            productRepository.save(product);

            orderDetailList.add(orderDetail);
        }
        order.setTotalPrice(totalPrice + 2.0);
        order.setOrderDetailList(orderDetailList);
        cartService.deleteCartById(shoppingCart.getId());
        return orderRepository.save(order);
    }

    @Override
    public List<Order> findAll(String username) {
        Customer customer = customerRepository.findByUsername(username);
        return customer.getOrders();
    }

    @Override
    public List<Order> findALlOrders() {
        return orderRepository.findAll();
    }

    @Override
    public Order acceptOrder(Long id) {
        Order order = orderRepository.getReferenceById(id);
        order.setAccept(true);
        order.setDeliveryDate(new Date());
        return orderRepository.save(order);
    }

    @Override
    public void cancelOrder(Long id) {
        orderRepository.deleteById(id);
    }

    @Override
    public void handleUpdateCartBeforeCheckout(List<CartItem> cartItems) {
        for (CartItem cartDetail : cartItems) {
            Optional<CartItem> cdOptional = this.cartItemRepository.findById(cartDetail.getId());
            if (cdOptional.isPresent()) {
                CartItem currentCartDetail = cdOptional.get();
                currentCartDetail.setQuantity(cartDetail.getQuantity());
                this.cartItemRepository.save(currentCartDetail);
            }
        }
    }

    @Override
    public void resetCartItemQuantity(List<CartItem> cartItems) {
        for (CartItem cartDetail : cartItems) {
            Optional<CartItem> cdOptional = this.cartItemRepository.findById(cartDetail.getId());
            if (cdOptional.isPresent()) {
                CartItem currentCartDetail = cdOptional.get();
                currentCartDetail.setQuantity(1);
                this.cartItemRepository.save(currentCartDetail);
            }
        }
    }

    @Override
    public Order getOrderById(Long orderId) {
        return this.orderRepository.findById(orderId).get();
    }
}
