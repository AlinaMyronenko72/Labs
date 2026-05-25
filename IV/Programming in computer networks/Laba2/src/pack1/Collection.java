package pack1;

public class Collection {
    private IProduct [] product;
    public int count(){
        if(product==null)
            return 0;
        return product.length;
    }
    public void add(Product p)
    {
        IProduct[] newProduct=new Product[count()+1];
        for(int i=0;i<count();i++)
            newProduct[i]=product[i];
        newProduct[count()]=p;
        product=newProduct;
    }
    public void sort(){
        IProduct temp;
        for (int i = 0; i < product.length - 1; i++)
        {
            for (int j = i + 1; j < product.length; j++)
            {
                if (product[i].getPrice() > product[j].getPrice())
                {

                    temp = product[i];
                    product[i] = product[j];
                    product[j] = temp;
                }
            }
        }

    }
    public IProduct getProduct(int index){
        return product[index];
    }

    public void print(){
        for (IProduct i:product){
            System.out.println(i);
        }
    }
}
