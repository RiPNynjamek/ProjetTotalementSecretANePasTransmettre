/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejb;

import java.util.List;
import javax.ejb.Local;
import jppa.hibernate.Mots;

/**
 *
 * @author Cyril
 */
@Local
public interface MotsFacadeLocal {

    void create(Mots mots);

    void edit(Mots mots);

    void remove(Mots mots);

    Mots find(Object id);

    List<Mots> findAll();

    List<Mots> findRange(int[] range);

    int count();
    
}
