package com.ecommerce.library.service;

import com.ecommerce.library.model.CartItem;
import com.ecommerce.library.model.Order;
import com.ecommerce.library.model.ShoppingCart;

import java.util.List;

public interface OrderService {

    Order save(ShoppingCart shoppingCart);

    List<Order> findAll(String username);

    List<Order> findALlOrders();

    Order acceptOrder(Long id);

    void cancelOrder(Long id);

    void handleUpdateCartBeforeCheckout(List<CartItem> cartItems);

    void resetCartItemQuantity(List<CartItem> cartItems);

    Order getOrderById(Long orderId);
}
