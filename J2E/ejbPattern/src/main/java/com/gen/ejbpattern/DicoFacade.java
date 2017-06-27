/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern;

import com.gen.ejbpattern.jpa.Dico;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author Cyril
 */
@Stateless
public class DicoFacade extends AbstractFacade<Dico> {

    @PersistenceContext(unitName = "com.gen_ejbPattern_ejb_1.0-SNAPSHOTPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public DicoFacade() {
        super(Dico.class);
    }
    
}
