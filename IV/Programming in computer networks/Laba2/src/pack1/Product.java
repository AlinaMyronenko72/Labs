package pack1;

abstract public class Product  implements IProduct{
    private String name;
    private double price;
    //static int id;
    static int counter;
    static double sum;

    static {
        counter=0;
        sum=0;
    }
    public Product() {
        name=null;
        price=0.0;
        counter++;
        sum+=price;
    }
    public Product(String n,double p)throws PriceException{
        name=n;
        price=p;
        if(price<0.0)
            throw new PriceException(p);
        counter++;
        sum+=price;
    }

    public void setName(String n){
        name=n;
    }
    public String getName(){
        return name;
    }
    public void setPrice(double p)throws PriceException {
        price=p;
        if(price<0.0)
            throw new PriceException(p);
    }
    public double getPrice(){
        return price;
    }
    public String toString(){
        return "Товар: "+name+", Цена: "+price;
    }
    public static void avg(){
        System.out.println(sum/counter);
    }
}
