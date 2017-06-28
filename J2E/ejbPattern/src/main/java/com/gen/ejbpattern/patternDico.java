/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern;

import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import org.json.JSONObject;
import com.gen.ejbpattern.model.dbOperations;


/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class patternDico implements iPattern{
     
    @Override
    public void searchPattern(String message) {
        JSONObject json = new JSONObject(message);
        System.out.println(json);
        message = json.getString("Message");
        System.out.println(message);
        dbOperations db = new dbOperations();
        db.searchWord(message);       
    }

    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}