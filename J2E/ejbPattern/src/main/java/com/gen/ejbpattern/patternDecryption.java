/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern;

import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import org.json.JSONObject;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class patternDecryption {

    public void patternEmail(String json){
         JSONObject jo = new JSONObject();
         jo.put("message","toto@gmail.com");
         jo.put("key","clé");
         String object = jo.toString();
         //JSONObject json = new JSONObject(object);
         /*if(object.toLowerCase().contains("@")){
             System.out.println("");
         }*/
    }
}
