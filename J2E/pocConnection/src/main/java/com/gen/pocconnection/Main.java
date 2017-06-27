/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.pocconnection;

import org.json.JSONObject;

/**
 *
 * @author Cyril
 */
public class Main {

    /**
     * @param args the command line arguments
     */

    public static void main(String[] args) {
        // TODO code application logic here
        patternMail mail = new patternMail();
        mail.searchPattern("toto");
    }
    
}
