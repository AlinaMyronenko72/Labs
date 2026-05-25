public class Clothes extends Product {
    private String country;
    private String material;

    Clothes() {
        super();
        country = null;
        material = null;
    }

    Clothes(String n, double p, String c, String m) {
        super(n, p);
        country = c;
        material = m;
    }

    void setCountry(String c) {
        country = c;
    }

    String getCountry() {
        return country;
    }

    void setMaterial(String m) {
        material = m;
    }

    String getMaterial() {
        return material;
    }

    public String toString() {
        return super.toString() + ", Страна производитель: " + country + ", Материал: " + material;
    }

}
