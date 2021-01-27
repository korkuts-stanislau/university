package data;

import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.BufferedReader;
import java.io.FileReader;

public class Path {
    public String commonPath;
    public String commonWinPath;
    public String commonLinuxPath;
    public String pathToPhoneChangeRequests;
    public String pathToDeclineServiceRequests;
    public String pathToAdmins;
    public String pathToSubscribers;
    public String pathToPhonePlans;
    public String pathToPhoneServices;

    public static Path getPath() throws Exception {
        String basePath;
        if(System.getProperty("os.name").contains("Windows")) {
             basePath = "D:\\university\\6sem\\java\\lab1\\src\\data\\paths.json";
        }
        else {
            basePath = "/home/stanislau/university/6sem/java/lab1/src/data/paths.json";
        }
        BufferedReader in = new BufferedReader(new FileReader(basePath));
        ObjectMapper mapper = new ObjectMapper();
        Path path = mapper.readValue(in, Path.class);
        if(System.getProperty("os.name").contains("Windows")) {
            path.commonPath = path.commonWinPath;
        }
        else {
            path.commonPath = path.commonLinuxPath;
        }
        return path;
    }
}
