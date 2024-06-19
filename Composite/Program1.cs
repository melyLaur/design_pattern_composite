namespace Composite
{
    
    /*
      * Component interface with
      * common operations to both simple
      * and complex object
    */
    public abstract class FileExplorer
    {

        public virtual void Add(FileExplorer component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(FileExplorer component)
        {
            throw new NotImplementedException();
        }
        public abstract int Count(); // => operation
        
        public virtual bool IsComposite()
        {
            return true;
        }
    }


    public class File : FileExplorer // => leaf
    {
        public override int Count()
        {
            return 1;
        }

        public override bool IsComposite()
        {
            return false;
        }
    }
    
    public class Folder : FileExplorer // => composite contains sub element
    {
        private readonly List<FileExplorer> _elements = new();

        public override void Add(FileExplorer component)
        {
            _elements.Add(component);
        }

        public override void Remove(FileExplorer component)
        {
            _elements.Remove(component);
        }

        public override int Count()
        {
            int res = 0;

            foreach (var content in _elements)
            {
                res += content.Count();
            }
            
            return res;
        }

    }

    public class FileExplorerService
    {
        public void GetTotalCount(FileExplorer fileExplorer)
        {
            Console.WriteLine($"RESULT: {fileExplorer.Count()}\n");
        }   
    }


    class Program1
    {

        static void Main(string[] args)
        {
            FileExplorerService fileExplorerService = new FileExplorerService();

            Folder folder = new Folder();
            folder.Add(new File());
            folder.Add(new File());
            folder.Add(new File());

            Folder subFolder = new Folder();
            subFolder.Add(new File());
            subFolder.Add(new File());
            
            Folder subFolder2 = new Folder();
            subFolder2.Add(new File());
            subFolder2.Add(new File());
            
            folder.Add(subFolder);
            folder.Add(subFolder2);
            
            fileExplorerService.GetTotalCount(folder);
        }
    }
}

