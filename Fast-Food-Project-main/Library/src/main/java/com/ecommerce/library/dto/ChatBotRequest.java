package com.ecommerce.library.dto;

public class ChatBotRequest {
    private String message;

    public ChatBotRequest() {
    }

    public ChatBotRequest(String message) {
        this.message = message;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}
