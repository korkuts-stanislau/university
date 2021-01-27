package data;

import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.BufferedReader;
import java.io.FileReader;

public class Path {
    private static final String basePath = "/home/stanislau/university/6sem/java/lab1/src/data/paths.json";

    public String commonPath;
    public String pathToPhoneChangeRequests;
    public String pathToDeclineServiceRequests;
    public String pathToAdmins;
    public String pathToSubscribers;
    public String pathToPhonePlans;
    public String pathToPhoneServices;

    public static Path getPath() throws Exception, JsonMappingException {
        BufferedReader in = new BufferedReader(new FileReader(basePath));
        ObjectMapper mapper = new ObjectMapper();
        return (Path)mapper.readValue(in, Path.class);
    }
}
