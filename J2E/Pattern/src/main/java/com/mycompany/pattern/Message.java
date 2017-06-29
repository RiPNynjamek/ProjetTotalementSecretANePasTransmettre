/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

/**
 *
 * @author antoi
 */
public class Message {
    
    public String Mail;
    public String Key;
    public float Confidence;
    
    public Message(String mail, String key, float confidence)
    {
        this.Mail = mail;
        this.Key = key;
        this.Confidence = confidence;
    }
    
}
