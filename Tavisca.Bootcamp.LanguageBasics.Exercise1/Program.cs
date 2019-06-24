using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
           float var1=0,var2=0,ans;
            int finalAns=0;
            String exp_ans=null,incomp_ans=null;
            int len=equation.Length;
            var IndexOfMulti=equation.IndexOf('*');
            var IndexOfEqual=equation.IndexOf('=');
            var z=IndexOfEqual-IndexOfMulti-1;
            //equation = "a*b=c"
            var a=equation.Substring(0,IndexOfMulti);
            var b=equation.Substring(IndexOfMulti+1,z);
            z=len-IndexOfEqual;
            var c=equation.Substring(IndexOfEqual+1,z-1);
            if(c.Contains('?'))
            {
                float.TryParse(a,out var1);
                float.TryParse(b,out var2);
                ans=var1*var2;
                exp_ans=ans.ToString();
                incomp_ans=c.ToString();
            }
            else
            {
                if(a.Contains('?')){
                float.TryParse(b,out var1);
                incomp_ans=a;}
                else if(b.Contains('?')){
                float.TryParse(a,out var1);
                incomp_ans=b;}
                float.TryParse(c,out var2);
                ans=var2/var1;
                exp_ans=ans.ToString();
            } 
            if (incomp_ans.Contains('?') && exp_ans.Length>0 && exp_ans.Length == incomp_ans.Length)
            {
                for(int i=0;i<exp_ans.Length ;i++)
                { 
                    if (exp_ans[i] != incomp_ans[i])  
                    {
                        if( incomp_ans[i]=='?')
                        {
                          int.TryParse(exp_ans[i].ToString(),out finalAns);
                          return finalAns;
                        }
                        else 
                        return -1;
                    }
                }
            }
        return -1;       
        }
    }
}