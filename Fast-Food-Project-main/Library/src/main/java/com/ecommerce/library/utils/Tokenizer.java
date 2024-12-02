package com.ecommerce.library.utils;

import org.springframework.stereotype.Component;

import opennlp.tools.tokenize.SimpleTokenizer;

@Component
public class Tokenizer {
    
    public String[] tokenize(String text) {
        SimpleTokenizer tokenizer = SimpleTokenizer.INSTANCE;
        return tokenizer.tokenize(text);
    }
}