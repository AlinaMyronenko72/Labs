package pack2;

import pack1.*;

public class Laba3 {
    public static void main(String args[]) {

        try {
            Collection<Product> c = new Collection<Product>();
            c.add(new Clothes("ddd1", 2, "ff1", "ddd1"));
            c.add(new Accessory("ddd2", 3, "ff2", "ddd2"));
            c.add(new Accessory("ddd3", 6, "ff3", "ddd3"));
            c.add(new Clothes("ddd4", 1, "ff4", "ddd4"));
            c.reverseIterator();

            c.GetPriceInTheInterval(2, 6);


        } catch (PriceException e) {
            System.out.println("Исключение перехвачено:" + e);
        } catch (IndexOutOfBoundsException e) {
            System.out.println("Индекс за пределами массива:" + e);
        }


    }
}
