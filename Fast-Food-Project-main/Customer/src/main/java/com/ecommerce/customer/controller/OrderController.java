package com.ecommerce.customer.controller;

import com.ecommerce.library.dto.CustomerDto;
import com.ecommerce.library.model.*;
import com.ecommerce.library.service.*;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;
import jakarta.servlet.http.HttpSession;

import java.security.Principal;
import java.util.ArrayList;
import java.util.List;

@Controller
public class OrderController {
    private final CustomerService customerService;
    private final OrderService orderService;
    private final CountryService countryService;
    private final CityService cityService;

    public OrderController(CustomerService customerService, OrderService orderService, CountryService countryService, CityService cityService) {
        this.customerService = customerService;
        this.orderService = orderService;
        this.countryService = countryService;
        this.cityService = cityService;
    }

    @GetMapping("/check-out")
    public String checkOut(Principal principal, Model model) {
        if (principal == null) {
            return "redirect:/login";
        } else {
            CustomerDto customer = customerService.getCustomer(principal.getName());
            if (customer.getAddress() == null || customer.getCity() == null || customer.getPhoneNumber() == null) {
                model.addAttribute("information", "You need update your information before check out");
                List<Country> countryList = countryService.findAll();
                List<City> cities = cityService.findAll();
                model.addAttribute("customer", customer);
                model.addAttribute("cities", cities);
                model.addAttribute("countries", countryList);
                model.addAttribute("title", "Profile");
                model.addAttribute("page", "Profile");
                return "customer-information";
            } else {
                ShoppingCart cart = customerService.findByUsername(principal.getName()).getCart();

                double grandTotal = 0.0;
                for (CartItem cartItem : cart.getCartItems()) {
                    grandTotal += (cartItem.getUnitPrice() * cartItem.getQuantity());
                }

                Country country = countryService.findById(Long.parseLong(customer.getCountry()));
                customer.setCountry(country.getName());
                model.addAttribute("customer", customer);
                model.addAttribute("title", "Check-Out");
                model.addAttribute("page", "Check-Out");
                model.addAttribute("shoppingCart", cart);
                model.addAttribute("grandTotal", String.format("%.2f", grandTotal));
                model.addAttribute("grandTotalWithTax", String.format("%.2f", grandTotal + 2.0));
                return "checkout";
            }
        }
    }

    @PostMapping("/confirm-checkout")
    public String getCheckoutPage(@ModelAttribute("shoppingCart") ShoppingCart cart) {
        List<CartItem> cartItems = cart == null ? new ArrayList<>() : cart.getCartItems();
        this.orderService.handleUpdateCartBeforeCheckout(cartItems);
        return "redirect:/check-out";
    }

    @GetMapping("/orders")
    public String getOrders(Model model, Principal principal) {
        if (principal == null) {
            return "redirect:/login";
        } else {
            Customer customer = customerService.findByUsername(principal.getName());
            List<Order> orderList = customer.getOrders();
            model.addAttribute("orders", orderList);
            model.addAttribute("size", orderList.size());
            model.addAttribute("title", "Order");
            model.addAttribute("page", "Order");
            return "order";
        }
    }

    @RequestMapping(value = "/cancel-order", method = {RequestMethod.PUT, RequestMethod.GET})
    public String cancelOrder(Long id, RedirectAttributes attributes) {
        orderService.cancelOrder(id);
        attributes.addFlashAttribute("success", "Cancel order successfully!");
        return "redirect:/orders";
    }

    @RequestMapping(value = "/add-order", method = {RequestMethod.POST})
    public String createOrder(Principal principal,
                              Model model,
                              HttpSession session) {
        if (principal == null) {
            return "redirect:/login";
        } else {
            Customer customer = customerService.findByUsername(principal.getName());
            ShoppingCart cart = customer.getCart();
            Order order = orderService.save(cart);
            session.removeAttribute("totalItems");
            model.addAttribute("order", order);
            model.addAttribute("title", "Order Successfully");
            model.addAttribute("page", "Order Successfully");
            return "order-success";
        }
    }

    @GetMapping("/order-detail/{id}")
    public String orderSuccessPage(@PathVariable("id") Long orderId, Model model, Principal principal) {
        if (principal == null) {
            return "redirect:/login";
        }
        
        Order order = this.orderService.getOrderById(orderId);
        model.addAttribute("order", order);
        model.addAttribute("title", "Order Detail");
        model.addAttribute("page", "Order Detail");
        return "order-detail";
    }
}
