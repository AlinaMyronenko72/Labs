public class Laba1 {
    public static void main(String args[])
    {
        /*Clothes a=new Clothes("ddd",2,"ff","ddd");
        Accessory b= new Accessory("ddd",2,"ff","ddd");
        Accessory c= new Accessory("ddd",2,"ff","ddd");
        Product.avg();
        System.out.println(a.toString());*/
        Collection c=new Collection();
        c.add(new Clothes("ddd1",2,"ff1","ddd1"));
        c.add(new Accessory("ddd2",3,"ff2","ddd2"));
        c.add(new Accessory("ddd3",6,"ff3","ddd3"));
        c.add(new Clothes("ddd4",1,"ff4","ddd4"));
        System.out.println(c.count());
        System.out.println(c.getProduct(1));

        c.print();
        c.sort();
        c.print();




    }
}
