package pack1;

public class Clothes extends Product implements IClothes{
    private String country;
    private String material;

    public Clothes(){
        super();
        country=null;
        material=null;
    }
    public Clothes(String n,double p,String c, String m)throws PriceException{
        super(n,p);
        country=c;
        material=m;
    }
    public void setCountry(String c){
        country=c;
    }
    public String getCountry(){
        return country;
    }
    public void setMaterial(String m){
        material=m;
    }
    public String getMaterial(){
        return material;
    }
    public String toString(){
        return super.toString()+", Страна производитель: "+country+", Материал: "+material;
    }

}
