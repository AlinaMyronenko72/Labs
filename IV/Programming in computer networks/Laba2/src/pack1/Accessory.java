package pack1;

public class Accessory extends Product implements IAccessory{
    private String brand;
    private String color;

    public Accessory(){
        super();
        brand=null;
        color=null;
    }
    public Accessory(String n,double p,String b, String c) throws PriceException{
        super(n,p);
        brand=b;
        color=c;
    }
    public void setBrand(String b){
        brand=b;
    }
    public String getBrand(){
        return brand;
    }
    public void setColor(String c){
        color=c;
    }
    public String getColor(){
        return color;
    }
    public String toString(){
        return super.toString()+", Бренд: "+brand+",Цвет: "+color;
    }
}
