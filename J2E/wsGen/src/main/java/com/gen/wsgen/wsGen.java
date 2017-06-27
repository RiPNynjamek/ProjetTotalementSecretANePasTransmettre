/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.wsgen;

import com.gen.ejbconnection.connection;
import javax.ejb.EJB;
import javax.jws.Oneway;
import javax.jws.WebMethod;
import javax.jws.WebService;

/**
 *
 * @author Cyril
 */
@WebService(serviceName = "wsGen")
public class wsGen {

    @EJB
    private connection ejbRef;// Add business logic below. (Right-click in editor and choose
    // "Web Service > Add Operation"

    @WebMethod(operationName = "send")
    @Oneway
    public void send() {
        ejbRef.send();
    }

    @WebMethod(operationName = "receive")
    @Oneway
    public void receive() {
        ejbRef.receive();
    }
   
}
