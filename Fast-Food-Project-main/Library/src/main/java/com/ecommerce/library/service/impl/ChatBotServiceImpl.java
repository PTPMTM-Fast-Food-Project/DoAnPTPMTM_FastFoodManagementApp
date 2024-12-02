package com.ecommerce.library.service.impl;

import java.io.File;
import java.nio.file.Paths;
import java.util.List;
import java.util.Random;

import org.springframework.stereotype.Service;

import com.ecommerce.library.dto.Intent;
import com.ecommerce.library.service.ChatBotService;
import com.ecommerce.library.utils.DatasetLoader;
import com.ecommerce.library.utils.IntentPredictor;
import com.ecommerce.library.utils.Tokenizer;

@Service
public class ChatBotServiceImpl implements ChatBotService {

    private final IntentPredictor intentPredictor;
    private final Tokenizer tokenizer;
    private final DatasetLoader datasetLoader;
    public static final String JSON_FILE_PATH = "Library\\src\\main\\java\\com\\ecommerce\\library\\utils\\dataset.json";

    public ChatBotServiceImpl(IntentPredictor intentPredictor, Tokenizer tokenizer, DatasetLoader datasetLoader) {
        this.intentPredictor = intentPredictor;
        this.tokenizer = tokenizer;
        this.datasetLoader = datasetLoader;
    }

    @Override
    public String getReply(String messageInput) {
        try {
            File file = Paths.get(JSON_FILE_PATH).toFile();
            List<Intent> intents = datasetLoader.loadDataset(file.getAbsolutePath());
            String[] tokenMessageInput = tokenizer.tokenize(messageInput);
            String intent = intentPredictor.predict(tokenMessageInput);

            for (Intent intentObj : intents) {
                if (intentObj.getIntent().contains(intent)) {
                    // Trả về câu trả lời ngẫu nhiên từ intent
                    return intentObj.getResponses().get(new Random().nextInt(intentObj.getResponses().size()));
                }
            }
        } catch (Exception e) {
            return "Xin lỗi, tôi không hiểu ý của bạn. " + e.getMessage();
        }
        return "Có lỗi xảy ra. Vui lòng thử lại sau.";
    }
}
