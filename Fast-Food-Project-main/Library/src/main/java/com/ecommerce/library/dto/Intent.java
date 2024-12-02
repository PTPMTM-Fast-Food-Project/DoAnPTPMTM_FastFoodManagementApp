package com.ecommerce.library.dto;

import java.util.List;

public class Intent {
    private String intent;
    private List<String> patterns;
    private List<String> responses;
    
    public Intent() {
    }

    public Intent(String intent, List<String> patterns, List<String> responses) {
        this.intent = intent;
        this.patterns = patterns;
        this.responses = responses;
    }

    public String getIntent() {
        return intent;
    }

    public void setIntent(String intent) {
        this.intent = intent;
    }

    public List<String> getPatterns() {
        return patterns;
    }

    public void setPatterns(List<String> patterns) {
        this.patterns = patterns;
    }

    public List<String> getResponses() {
        return responses;
    }

    public void setResponses(List<String> responses) {
        this.responses = responses;
    }
}
