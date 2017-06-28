/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern;

import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import org.json.JSONObject;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class patternMail implements iPattern{
    public static final Pattern VALID_EMAIL_ADDRESS_REGEX = 
    Pattern.compile("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])", Pattern.CASE_INSENSITIVE);
    private Boolean mailFinded;
    private String message;
    @Override
    public void searchPattern(String object) {
        setMailFinded((Boolean) false);
        //System.out.println(message);
        if(message.toLowerCase().contains("@")){
            Matcher matcher = VALID_EMAIL_ADDRESS_REGEX.matcher(message);
            if(matcher.find()){
                System.out.println(message +" est une adresse mail");
                setMailFinded((Boolean) true);
            }else{
                System.out.println(message +" n'est pas une adresse mail");
            }
        }
    }

    /**
     * @return the mailFinded
     */
    public Boolean getMailFinded() {
        return mailFinded;
    }

    /**
     * @param mailFinded the mailFinded to set
     */
    public void setMailFinded(Boolean mailFinded) {
        this.mailFinded = mailFinded;
    }
}
