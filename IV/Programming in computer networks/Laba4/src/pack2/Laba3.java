package pack2;

import pack1.*;

public class Laba3 {
    public static void main(String args[]) {

        try {
            Collection<Product> c = new Collection<Product>();
            Collection<Product> c1 = new Collection<Product>();
            c.add(new Clothes("ddd1", 2, "ff1", "ddd1"));
            c.add(new Accessory("ddd2", 3, "ff2", "ddd2"));
            c.add(new Accessory("ddd3", 6, "ff3", "ddd3"));
            c.add(new Clothes("ddd4", 1, "ff4", "ddd4"));
            //Accessory q=new Accessory();
           // c.add(q);
           // pack1.Accessory b = new pack1.Accessory();
            //q.clone(b);
           // System.out.println(q.toString());
            //c.add(q);
            //c.print();
            c1.clone(c);
            c1.print();
            // c1.count();

            //c.reverseIterator();
            //c.GetPriceInTheInterval(2,6);
            //System.out.println(avgPrice(c));
            /*pack1.Clothes a = new pack1.Clothes("ddd", 3, "ff", "ddd");
            pack1.Clothes a1=new Clothes();
            pack1.Accessory b = new pack1.Accessory("ddd1", 5, "ff1", "ddd1");
            pack1.Accessory b1=new Accessory();

            a1.clone(a);
            System.out.println(a1.toString());
            b1.clone(b);
            System.out.println(b1.toString());*/





        } catch (PriceException e) {
            System.out.println("Исключение перехвачено:" + e);
        } catch (IndexOutOfBoundsException e) {
            System.out.println("Индекс за пределами массива:"+ e);
        }
    }
    static double avgPrice(Collection<Product> p)
    {
        double sum=0;
        int count=p.count();
        for (int i=0;i<count;i++)
        {
            sum+= p.getProduct(i).getPrice();

        }
        return sum/count;
    }
}
