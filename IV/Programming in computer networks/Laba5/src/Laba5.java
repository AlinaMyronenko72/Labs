import java.io.File;
import java.io.FilenameFilter;
import java.util.*;


public class Laba5 {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.print("Введите путь к папке: ");
        String dir = in.nextLine();
        in.close();
        //String dir = "D:/Laba5";
        String ext1 = ".jpg";
        String ext2 = ".gif";
        HashMap<String, String> hm = getFiles(dir, ext1);
        Set<Map.Entry<String, String>> set = hm.entrySet();
        for (Map.Entry<String, String> me : set) {
            System.out.print(me.getKey() + ": ");
            System.out.print(me.getValue() + ": ");
            System.out.println(me.getKey().hashCode() + ", ");
        }
        System.out.println();
        HashMap<String, String> hm2 = getFiles(dir, ext2);
        Set<Map.Entry<String, String>> set2 = hm2.entrySet();
        for (Map.Entry<String, String> me : set2) {
            System.out.print(me.getKey() + ": ");
            System.out.print(me.getValue() + ": ");
            System.out.println(me.getKey().hashCode() + ", ");
        }
        System.out.println();
        Scanner in2 = new Scanner(System.in);
        System.out.print("Введите имя файла: ");
        String nameOfFile = in2.nextLine();
        in2.close();
        //String nameOfFile="mypicture.jpg";
        for (Map.Entry<String, String> me : set) {
           if(me.getKey().equals(nameOfFile))
           {
               System.out.println(me.getValue());
           }
        }

    }

    private static HashMap getFiles(String dir, String ext) {
        HashMap<String, String> hm = new HashMap<String, String>();
        File f = new File(dir);
        if (!f.exists())
            System.out.println("Такой папки не существует!");
        MyFilter filter = new MyFilter(ext);
        String[] list = f.list(filter);
        for (String f1 : list) {
            MyFile myFile = new MyFile(f1);
            hm.put(myFile.key, myFile.value);
        }

        return hm;
    }

    public static int setHashCode(String name) {
        char[] a = name.toCharArray();
        Character c1 = Character.valueOf(a[0]);
        int first = c1.hashCode();
        Character c2 = Character.valueOf(a[1]);
        int second = c2.hashCode();
        Character c3 = Character.valueOf(a[2]);
        int third = c3.hashCode();
        Character c4 = Character.valueOf(a[3]);
        int forth = c4.hashCode();
        int mul = first * second * third * forth;
        return mul;
    }

    public static class MyFilter implements FilenameFilter {
        String ext;
        public MyFilter(String ext) {
            this.ext = ext;
        }
        public boolean accept(File dir, String name) {
            return name.endsWith(ext);
        }
    }

    public static class MyFile {
        String key;
        String value;
        public MyFile(String k) {
            key = k;
            value = "описание " + k;
        }
        @Override
        public int hashCode() {
            return setHashCode(key);
        }


    }
}

