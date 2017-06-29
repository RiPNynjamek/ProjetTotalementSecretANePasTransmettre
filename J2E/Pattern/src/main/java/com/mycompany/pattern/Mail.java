/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class Mail implements iPattern {
    public static final Pattern VALID_EMAIL_ADDRESS_REGEX = 
    Pattern.compile("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])", Pattern.CASE_INSENSITIVE);
    public boolean isFound = false;
    private String stringMatch;

    public void searchPattern(String message, String key) {
        //System.out.println(message);
        if(message.isEmpty() || message == null)
        {
            isFound = false;
            return;
        }
        if(message.toLowerCase().contains("@")){
            Matcher matcher = VALID_EMAIL_ADDRESS_REGEX.matcher(message);
            if(matcher.find()){
                isFound = true;
                System.out.println(message + " est une adresse mail");
                stringMatch = matcher.group();
            }else{
                isFound = false;
                System.out.println(message  +" n'est pas une adresse mail");
            }
        }
    }
    public String getStringMatch() {
         return stringMatch;
    }
 
     /**
      * @param stringMatch the stringMatch to set
      */
     public void setStringMatch(String stringMatch) {
         this.stringMatch = stringMatch;
    }
}
