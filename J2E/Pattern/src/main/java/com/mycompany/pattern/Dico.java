/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class Dico {
    public float tauxConfiance;
    
    public void searchPattern(String message, String key) {
        dbOperations db = new dbOperations();
        tauxConfiance = db.searchWord(message, key);       
    }
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
