package com.lab3;

public class TaskCipherStrategy extends CipherStrategy {
    @Override
    public String encrypt(String text) {
        char[] charText = text.toCharArray();
        StringBuilder builder1 = new StringBuilder();
        StringBuilder builder2 = new StringBuilder();
        StringBuilder builder3 = new StringBuilder();
        int flag = 1;
        for(int i = 0; i < text.length(); i++) {
            switch(flag) {
                case 1:
                    builder1.append(charText[i]);
                    break;
                case 2:
                    builder2.append(charText[i]);
                    break;
                case 3:
                    builder3.append(charText[i]);
                    break;
            }
            if(flag == 3)
                flag = 1;
            else
                flag += 1;
        }
        return builder1.toString() + builder2.toString() + builder3.toString();
    }

    @Override
    public String decrypt(String text) {
        System.out.println("Этого пункта нет в задании");
        return "";
    }
}
