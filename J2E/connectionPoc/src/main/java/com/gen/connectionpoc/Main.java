/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.connectionpoc;

import com.gen.connectionpoc.connection;

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
        System.out.println("begin");
        connection co = new connection(); 
        co.receive();
        co.send();
    }
}
    

