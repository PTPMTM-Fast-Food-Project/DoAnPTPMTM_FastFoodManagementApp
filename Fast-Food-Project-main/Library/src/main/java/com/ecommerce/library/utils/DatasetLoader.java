package com.ecommerce.library.utils;

import java.util.List;
import java.io.File;

import org.springframework.stereotype.Component;

import com.ecommerce.library.dto.Intent;
import com.fasterxml.jackson.databind.ObjectMapper;

@Component
public class DatasetLoader {
    
    public List<Intent> loadDataset(String filePath) throws Exception {
        ObjectMapper mapper = new ObjectMapper();
        return List.of(mapper.readValue(new File(filePath), Intent[].class));
    }
}
