/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class Dico implements iPattern {
    public float tauxConfiance;
    
    public void searchPattern(String message, String key) {
        try {
            dbOperations db = new dbOperations();       
            tauxConfiance = db.searchWord(message, key);
        } catch (Exception ex) {
            Logger.getLogger(Dico.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
