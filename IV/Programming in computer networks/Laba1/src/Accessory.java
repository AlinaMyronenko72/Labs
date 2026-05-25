public class Accessory extends Product{
private String brand;
private String color;

Accessory(){
    super();
    brand=null;
    color=null;
}
Accessory(String n,double p,String b, String c){
    super(n,p);
    brand=b;
    color=c;
}
void setBrand(String b){
    brand=b;
}
String getBrand(){
    return brand;
}
void setColor(String c){
    color=c;
}
String getColor(){
    return color;
}
public String toString(){
    return super.toString()+", Бренд: "+brand+",Цвет: "+color;
}
}
