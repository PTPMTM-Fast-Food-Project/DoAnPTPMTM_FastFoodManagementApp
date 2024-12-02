package com.ecommerce.library.utils;

import org.springframework.stereotype.Component;

import com.ecommerce.library.dto.Intent;

import opennlp.tools.doccat.DoccatFactory;
import opennlp.tools.doccat.DoccatModel;
import opennlp.tools.doccat.DocumentCategorizerME;
import opennlp.tools.doccat.DocumentSample;
import opennlp.tools.doccat.DocumentSampleStream;
import opennlp.tools.util.InputStreamFactory;
import opennlp.tools.util.ObjectStream;
import opennlp.tools.util.PlainTextByLineStream;
import opennlp.tools.util.TrainingParameters;

import java.io.*;
import java.nio.file.Paths;
import java.util.List;

@Component
public class IntentTrainer {
    private final DatasetLoader datasetLoader;
    private final TrainingDataGenerator trainingDataGenerator;
    public static final String JSON_FILE_PATH = "Library\\src\\main\\java\\com\\ecommerce\\library\\utils\\dataset.json";
    public static final String TRAINING_DATA_FILE_PATH = "Library\\src\\main\\java\\com\\ecommerce\\library\\utils\\data-training.txt";
    public static final String INTENT_MODEL_FILE_PATH = "Library\\src\\main\\java\\com\\ecommerce\\library\\utils\\intent-model.bin";

    public IntentTrainer(DatasetLoader datasetLoader, TrainingDataGenerator trainingDataGenerator) {
        this.datasetLoader = datasetLoader;
        this.trainingDataGenerator = trainingDataGenerator;
    }

    public void trainModel() {
        try {
            File fileJson = Paths.get(JSON_FILE_PATH).toFile();
            File fileTrainingData = Paths.get(TRAINING_DATA_FILE_PATH).toFile();
            File fileIntentModel = Paths.get(INTENT_MODEL_FILE_PATH).toFile();

            List<Intent> intents = datasetLoader.loadDataset(fileJson.getAbsolutePath());
            trainingDataGenerator.generateTrainingData(intents, fileTrainingData.getAbsolutePath());

            InputStreamFactory inputStreamFactory = () -> new FileInputStream(fileTrainingData.getAbsolutePath());
            ObjectStream<String> lineStream = new PlainTextByLineStream(inputStreamFactory, "UTF-8");
            ObjectStream<DocumentSample> sampleStream = new DocumentSampleStream(lineStream);

            TrainingParameters trainingParameters = new TrainingParameters();

            // Số lần lặp qua tập dữ liệu
            trainingParameters.put(TrainingParameters.ITERATIONS_PARAM, "100");

            // Kích thước batch
            trainingParameters.put(TrainingParameters.THREADS_PARAM, "32");

            // Giá trị cutoff
            trainingParameters.put(TrainingParameters.CUTOFF_PARAM, "5");

            // Thuật toán tối ưu hóa
            trainingParameters.put(TrainingParameters.ALGORITHM_PARAM, "MAXENT_QN");

            // Truyền TrainingParameters vào train()
            DoccatModel model = DocumentCategorizerME.train("en", sampleStream, trainingParameters, new DoccatFactory());

            FileOutputStream modelOut = new FileOutputStream(fileIntentModel.getAbsolutePath());
            model.serialize(modelOut);
            modelOut.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
