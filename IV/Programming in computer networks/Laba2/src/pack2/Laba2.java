package pack2;

import pack1.*;

public class Laba2 {
    public static void main(String args[]) {
        /*try {
            pack1.Clothes c = new pack1.Clothes("ddd", 3, "ff", "ddd");
            c.setPrice(-4);

            pack1.Accessory a = new pack1.Accessory("ddd1", 5, "ff1", "ddd1");
            System.out.println(c.toString());
            Product.avg();
        } catch (PriceException e) {
            System.out.println("Исключение перехвачено:" + e);
        }
        try {
            IClothes a = new Clothes("ddd", 2, "ff", "ddd");
            IAccessory b = new Accessory("ddd1", 4, "ff1", "ddd1");
            System.out.println(a.toString());
            Product.avg();
        } catch (PriceException e) {
            System.out.println("Исключение перехвачено:" + e);
        }*/


        try {
            pack1.Collection c = new Collection();
            c.add(new Clothes("ddd1", -2, "ff1", "ddd1"));
            c.add(new Accessory("ddd2", 3, "ff2", "ddd2"));
            c.add(new Accessory("ddd3", 6, "ff3", "ddd3"));
            c.add(new Clothes("ddd4", 1, "ff4", "ddd4"));
            System.out.println(c.count());
            System.out.println(c.getProduct(2));
            c.print();
            c.sort();
            c.print();


        } catch (PriceException e) {
            System.out.println("Исключение перехвачено:" + e);
        } catch (IndexOutOfBoundsException e) {
            System.out.println("Индекс за пределами массива:");
        }


    }
}
