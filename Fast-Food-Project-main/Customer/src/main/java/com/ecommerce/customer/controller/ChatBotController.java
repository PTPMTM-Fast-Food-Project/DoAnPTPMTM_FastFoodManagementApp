package com.ecommerce.customer.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.ecommerce.library.dto.ChatBotRequest;
import com.ecommerce.library.dto.ChatBotResponse;
import com.ecommerce.library.service.ChatBotService;

@RestController
@RequestMapping("/api/chatbot")
public class ChatBotController {
    private final ChatBotService chatBotService;

    public ChatBotController(ChatBotService chatBotService) {
        this.chatBotService = chatBotService;
    }

    @PostMapping("/get-reply")
    public ResponseEntity<ChatBotResponse> handleMessage(@RequestBody ChatBotRequest request) {
        String reply = chatBotService.getReply(request.getMessage());
        return ResponseEntity.ok().body(new ChatBotResponse(reply));
    }
}
