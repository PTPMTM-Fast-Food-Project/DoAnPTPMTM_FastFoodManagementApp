package com.ecommerce.library.utils;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.nio.file.Paths;

import org.springframework.stereotype.Component;

import opennlp.tools.doccat.DoccatModel;
import opennlp.tools.doccat.DocumentCategorizerME;

@Component
public class IntentPredictor {
    private final IntentTrainer intentTrainer;

    public IntentPredictor(IntentTrainer intentTrainer) {
        this.intentTrainer = intentTrainer;
    }

    public String predict(String[] userInput) throws Exception {
        File file = Paths.get(IntentTrainer.INTENT_MODEL_FILE_PATH).toFile();

        if (!file.exists()) {
            intentTrainer.trainModel();
        }

        InputStream modelIn = new FileInputStream(file.getAbsolutePath());
        DoccatModel model = new DoccatModel(modelIn);

        DocumentCategorizerME categorizer = new DocumentCategorizerME(model);
        double[] outcomes = categorizer.categorize(userInput);
        return categorizer.getBestCategory(outcomes);
    }
}
