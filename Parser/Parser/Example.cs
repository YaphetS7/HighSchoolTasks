using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Каждый объект данного класса хранит в себе:
///начало и конец класса(по нумерации строк),
///название класса,
///список полей, список методов данного класса.
/// </summary>
public class Interval
{
    public int start, end;
    public string nameOfClass;
    public List<Method> methods = new List<Method>();
    public List<Field> fields = new List<Field>();
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

/// <summary>
/// Класс, в котором хранится список ошибок с их описаниями.
/// </summary>
public class Exceptions
{
    public string ErrorType = " невозможно преобразовать ";
    public string ErrorCntOfOptions = " неверное кол-во параметров метода ";
    public string ErrorTypesAtMethod = " неверный тип параметра(-ов) метода ";
    public string ErrorFindMethod = " класс не содержит вызываемого поля/метода ";
}

/// <summary>
/// Каждый экземпляр данного класса содержит(описывает public-поле какого-то класса):
///название поля,
///тип поля.
/// </summary>
public class Field
{
    public string name;
    public string type;
}

/// <summary>
/// Каждый экземпляр данного класса содержит(описывает public-метод какого-то класса):
///название метода,
///тип возвращаемого значения,
///список его параметров.
/// </summary>
public class Method
{
    public string returnType;
    public string name;
    public List<string> typeOfOptions = new List<string>();
}

/// <summary>
/// Класс, реализующий всю основную логику решения задачи и инкапсулирующий ее
/// </summary>
public class Solution
{
    private int startsearch;
    private int endsearch;
    public List<Interval> classes = new List<Interval>();
    public Solution(string[] test)
    {
        //запускаем предобработку текстового файла
        Preprocessing(test);
       
        for (int i = 0; i < test.Length; i++)
        {
            if (test[i].Contains("class") && !test[i].Contains("Program"))
            {
                string[] temp = test[i].Split(' ');
                int start = i;
                int end = Parse(i, test);
                //добавляем новый класс с интервалом
                classes.Add(new Interval(start, end));
                //присваиваем имя классу
                classes[classes.Count - 1].nameOfClass = FindName(temp);
            }
        }
        //разбиваем класс на поля, методы(запоминаем только public(т.к. только они доступны в интерфейсе для пользователя))
        SplitClass(test);
        //окончательная проверка корректности обращений ко всем описанным в программе классам, их полям и методам
        CheckAllText(test);
    }
    //парсит класс на методы(его параметры и типы параметров), поля, их типы
    private void SplitClass(string[] str)
    {
        foreach(Interval interval in classes)
        {
            HelpSplit(interval, str);
        }
    }
    //вспомогательный метод, выполняющий основную работу по разбиению класса
    private void HelpSplit(Interval interval, string[] text)
    {
        for(int i = interval.start + 1; i <= interval.end; i++)
        {
            if (text[i].Contains("public"))
            {
                if (text[i].Contains("("))
                {
                    string[] temp = text[i].Split(new char[] {' ', ',', '(', ')' });
                    Method method = new Method();
                    method.returnType = temp[2];
                    method.name = temp[3];
                    if (!text[i].Contains("()"))
                    {
                        for (int j = 4; j < temp.Length - 2; j+=2)
                        {
                            method.typeOfOptions.Add(temp[j]);
                        }
                    }
                    interval.methods.Add(method);
                }
                else
                {
                    string[] temp = text[i].Split(new char[] { ' ', ',' });
                    for (int j = 3; j < temp.Length; j ++)
                    {
                        Field field = new Field();
                        field.name = temp[j];
                        field.type = temp[2];
                        if (field.name.Contains(";"))
                            field.name = field.name.Replace(";", "");
                        interval.fields.Add(field);
                    }
                }
            }
        }
    }
    //метод, проверяющий правильность обращения к полям и методам классов в методе Main
    //(можно масштабировать на весь исходный текст)
    private void CheckAllText(string[] text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i].Contains("Main"))
            {
                int start = i;
                startsearch = start;
                int end = Parse(i, text);
                endsearch = end;
                Scanner(start, end, text);
                break;
            }
        }
    }
    //находит объект класса, определяет к какому классу он принадлежит 
    //и проверяет дальнейшие обращения к этому объекту класса
    private void Scanner(int start, int end, string[] text)
    {
        for (int i = start; i <= end; i++)
        {
            if(text[i].Contains("new"))
            {
                string[] temp = text[i].Split(' ');

                string NameOfClass = temp[1];
                string NameOfParam = temp[2];
                if (CheckClass(NameOfClass))
                    Finish(i + 1, end, NameOfClass, NameOfParam, text);
            }
        }
    }
    //проверка на использование именно ОПИСАННОГО пользователем класса, а не использование встроенной библиотеки/класса
    public bool CheckClass(string NameOfClass)
    {
        foreach(Interval interval in classes)
        {
            if (interval.nameOfClass == NameOfClass)
                return true;
        }
        return false;
    }
    public void Finish(int start, int end, string NameOfClass, string NameOfParam, string[] text)
    {
        for (int i = start; i <= end; i++)
        {
            if (text[i].Contains(NameOfParam))
            {
                if (text[i].Contains("="))
                    CheckOnErrorType(text[i], NameOfClass, text, start, end, i);
                if (text[i].Contains("("))
                    CheckOnErrorCntOfOptions(text[i], NameOfClass, i, text, start, end);
            }
        }
    }
    private void CheckOnErrorType(string str, string NameOfClass, string[] text, int start, int end, int line)
    {
        string[] temp = str.Split(new char[] { ' ', ',', '(', ')', '.' });
       
        string leftType = "";
        string rightType = "";
        string methodName;
        //если переменная до знака равно создана до текущей строки
        if (temp[2] == "=")
        {
            methodName = temp[4];
            for(int i = start; i <= end; i++)
            {
                if(text[i].Contains(temp[1]))
                {
                    string[] splited = text[i].Split(' ');
                    leftType = splited[1];
                    break;
                }
            }
        }
        else
        {
            methodName = temp[5];
            leftType = temp[1];
        }

        foreach (Interval interval in classes)
        {
            if (interval.nameOfClass == NameOfClass)
            {
                foreach (Method method in interval.methods)
                {
                    if (method.name == methodName)
                    {
                        rightType = method.returnType;
                        break;
                    }
                }
                foreach (Field field in interval.fields)
                {
                    if (field.name == methodName)
                    {
                        rightType = field.type;
                        break;
                    }
                }
                break;
            }
        }
        if (leftType != rightType && rightType != "")
            Console.WriteLine("Строка: " + (line + 1) + new Exceptions().ErrorType + leftType + " в " + rightType);
    }
    private void CheckOnErrorCntOfOptions(string str, string NameOfClass, int line, string[] text,int start, int end)
    {
        string[] temp = str.Split(new char[] { ' ', ',', '(', ')', '.' });
        int leftcnt = 0, rightcnt = -1, i;
        string methodName;
        if (str.Contains("="))
        {
            if (temp[3].Contains("="))
            {
                methodName = temp[5];
                i = 5;
            }
            else
            {
                methodName = temp[4];
                i = 4;
            }
        }
        else
        {
            methodName = temp[2];
            i = 2;
        }
        leftcnt = temp.Length - i - 1;
        foreach (Interval interval in classes)
        {
            if (interval.nameOfClass == NameOfClass)
            {
                foreach (Method method in interval.methods)
                {
                    if (method.name == methodName)
                    {
                        rightcnt = method.typeOfOptions.Count;
                        break;
                    }
                }
                break;
            }
        }
        if (rightcnt == -1)
            CheckOnErrorFindMethod(str, NameOfClass, line);
        else
        {
            if (leftcnt - 1!= rightcnt)
                Console.WriteLine("Строка: " + (line + 1) + new Exceptions().ErrorCntOfOptions);
            else
            {
                CheckOnErrorTypesAtMethod(str, NameOfClass, line, text, start, end);
            }
        }
    }
    private void CheckOnErrorTypesAtMethod(string str, string NameOfClass, int line, string[] text, int start, int end)
    {
        string[] temp = str.Split(new char[] { ' ', ',', '(', ')', '.' });
       
        int i;
        string methodName;
        if (str.Contains("="))
        {
            if (temp[2].Contains("="))
            {
                methodName = temp[4];
                i = 4;
            }
            else
            {
                methodName = temp[5];
                i = 5;
            }
        }
        else
        {
            methodName = temp[2];
            i = 2;
        }
        i++;
        string[] types = new string[temp.Length];
        for(int j = 0; j <= end; j++)
        {
            if(temp.Length - 1 == i)
            {
                break;
            }
            types[j] = FindType(start, end, text, temp[i]);
            i++;
        }
        i = 0;
       
        foreach (Interval interval in classes)
        {
            if (interval.nameOfClass == NameOfClass)
            {
                foreach (Method method in interval.methods)
                {
                    if (method.name == methodName)
                    {
                        foreach (string s in method.typeOfOptions)
                        {
                           
                            if (types[i] != s)
                            {
                                Console.WriteLine("Строка: " + (line + 1) + new Exceptions().ErrorTypesAtMethod);
                                break;
                            }
                            i++;
                        }
                        break;
                    }
                }
                break;
            }
        }
    }
    private string FindType(int start, int end, string[] text, string curr)
    {
        string type = "";
        for (int i = startsearch + 1; i <= endsearch; i++)
        {
            if (text[i].Split(' ').Length > 2 && text[i].Split(' ')[2] == curr)
            {
                type = text[i].Split(' ')[1];
                break;
            }
        }

        return type;
    }
    private void CheckOnErrorFindMethod(string str, string NameOfClass, int line)
    {
        Console.WriteLine("Строка: " + (line + 1) + new Exceptions().ErrorFindMethod);
    }
    //находит имя класса
    private string FindName(string[] str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            if (str[i] == "class")
                return str[i + 1];
        }
        return null;
    }
    //предобработка текста
    private void Preprocessing(string[] str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            str[i] = DeleteSpaces(str[i]);
            //сюда можно дописать еще возможные варианты предобработки исходного текста(по надобности)
        }
    }
    //удаление 2+ повторяющихся пробелов
    private string DeleteSpaces(string str)
    {
        string s1 = "  ";
        string s2 = " ";
        if (str.Contains("="))
            str = str.Replace("=", " = ");
        for (int i = 0; i < 100; i++)
        {
            if (str.Contains(s1))
                str = str.Replace(s1, s2);
        }
        if (str.Contains(", "))
            str = str.Replace(", ", ",");
        return str;
    }
    //нахождение интервала класса(первая и последняя строки класса)
    public int Parse(int i, string[] text)
    {
        while (!text[i].Contains("{"))
            i++;

        Stack<int> stack = new Stack<int>();
        for (int j = i; j < text.Length; j++)
        {
            if (text[j].Contains("{"))
                stack.Push(1);

            if (text[j].Contains("}"))
                stack.Pop();

            if (stack.Count == 0)
                return j;
        }

        return -1;
    }
}
class Example
{
    
    static void Main()
    {
        // Массив тестируемых строк
        string[] test = File.ReadAllLines("test.txt");
        Solution mysolution = new Solution(test);
        
       



    }
}