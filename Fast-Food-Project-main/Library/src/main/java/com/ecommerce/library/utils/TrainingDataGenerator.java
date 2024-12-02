package com.ecommerce.library.utils;

import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;

import com.ecommerce.library.dto.Intent;

@Component
public class TrainingDataGenerator {
    public void generateTrainingData(List<Intent> intents, String outputPath) throws Exception {
        FileOutputStream fos = new FileOutputStream(outputPath);
        OutputStreamWriter writer = new OutputStreamWriter(fos, "UTF-8");
        List<String> lines = new ArrayList<>();
        
        for (Intent intent : intents) {
            for (String pattern : intent.getPatterns()) {
                lines.add(intent.getIntent() + "\t" + pattern + "\n");
            }
        }

        int idx = 0;
        for (String line : lines) {
            if (idx == lines.size() - 1)
                writer.write(line.trim());
            else
                writer.write(line);
            idx++;
        }
        writer.close();
        fos.close();
    }
}
