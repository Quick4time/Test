using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Все для двухмерного пространства, но при добавлении z ничего не поменяется.
#region 1-й урок Math for Game Developers - Character Movement (Points and Vectors)
// P' = (Px + Vx, Py + Vy);
/*
public class Vector // вектор направления
{
    public float x, y;
}

public class Point // текущая позицию
{
    public float x, y;
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }
}
public class GameMath : MonoBehaviour
{
    Point p2 = new Point();
    Vector v1 = new Vector();
    
    void Start ()
    {
        p2.x = 1;
        p2.y = 2;
        v1.x = 3;
        v1.y = 5;

        p2 = p2.AddVector(v1);
        print(p2.x.ToString() + p2.y.ToString());
    }
}
*/
#endregion

#region 2-й урок Math for Game Developers - Character Movement 2 (Subtracting Vectors)
/*
public class Vector
{
    public float x, y;
}

public class Point
{
    public float x, y;
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    } 
}

public class GameMath : MonoBehaviour
{
    Point p1 = new Point(); // указывем точку одного обьекта
    Point p2 = new Point(); // указывем точку второго обьекта

    void Start()
    {
        p1.x = 0;
        p1.y = -1;

        p2.x = 1;
        p2.y = 1;

        Vector v;

        v = p1 - p2;

        print(v.x.ToString() + " " + v.y.ToString());

    }
}
*/
#endregion

#region 3-й урок Math for Game Developers - Character Movement 3 (Vector Length)
/*
public class Vector
{
    public float x, y;
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
}

public class Point
{
    public float x, y;
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    Point p1 = new Point(); // указывем точку одного обьекта
    Point p2 = new Point(); // указывем точку второго обьекта

    void Start()
    {
        p1.x = 0;
        p1.y = -1;
        p2.x = 1;
        p2.y = 1;
        Vector v;
        v = p1 - p2;

        float length = v.Length();

        print(length.ToString());

    }
}
*/
#endregion

#region 4-й урок Math for Game Developers - Distance Comparison
/*
public class Vector
{
    public float x, y;
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
}

public class Point
{
    public float x, y;
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    Point p = new Point(); // указывем точку одного обьекта
    Point i = new Point(); // указывем точку второго обьекта
    Point c = new Point(); // указывем точку второго обьекта

    void Start()
    {
        p.x = 0;
        p.y = -1;

        i.x = 1;
        i.y = 1;

        c.x = 2;
        c.y = -1;

        Vector cp;
        Vector ip;
        cp = p - c;
        ip = p - i;

        float lenght_sqr_cp = cp.LengthSqr();
        float lenght_sqr_ip = ip.LengthSqr();
        // эти два вектора мы можем сравнить и получить ближайшую точку.

        print(string.Format("lenght_cp: {0} \nlenght_ip: {1}", lenght_sqr_cp, lenght_sqr_ip));
    }
}
*/
#endregion

#region 5-й урок Math for Game Developers - Character Movement 4 (Vector Scaling)
/*
public class Vector
{
    
    public Vector() { }
    public float x, y;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; // формула для увелечения длины вектора путем умножения.
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; // формула для уменьшения длины вектора путем деления.
        scaled.y = v.y / s;
        return scaled;
    }
}

public class Point
{
    public float x, y;
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    Point p = new Point(); // указывем точку одного обьекта
    Point i = new Point(); // указывем точку второго обьекта
    Point c = new Point(); // указывем точку второго обьекта

    void Start()
    {
        Vector v = new Vector(3, 4);
        print(v.Length());

        Vector doubled;
        doubled = v * 2;
        print(doubled.Length());

        Vector halved;
        halved = v / 2;
        print(halved.Length());
    }
}
*/
#endregion

#region 6-й урок Math for Game Developers - Character Movement 5 (Unit-Length Vectors)
/*
public class Vector
{
    public Vector() { }
    public float x, y;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length(); // формула для normalized 
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; // формула для увелечения длины вектора путем умножения.
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; // формула для уменьшения длины вектора путем деления.
        scaled.y = v.y / s;
        return scaled;
    }
}

public class Point
{
    public Point() { }
    public float x, y;
    public Point (float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }
    
    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    Point p = new Point(); // указывем точку одного обьекта
    Point i = new Point(); // указывем точку второго обьекта
    Point c = new Point(); // указывем точку второго обьекта

    void Start()
    {
        Point i = new Point(3, 4);
        Point p = new Point(1, 2);

        Vector pi = i - p; // PI - направление взгляда в стоону I.

        Vector normalized = pi.Normalized(); // далее производим нормализацию т.е направления всгляда будет вектор длиною не больше 1.

        print(string.Format("View vector: ({0}, {1})", normalized.x, normalized.y));
        print(string.Format("View vector length: ({0})", normalized.Length()));
    }
}
*/
#endregion

#region 7-й урок Math for Game Developers - Character Movement 6 (Adding Vectors)
/*
public class Vector
{
    public Vector() { }
    public float x, y;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length(); // формула для normalized 
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; // формула для увелечения длины вектора путем умножения.
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; // формула для уменьшения длины вектора путем деления.
        scaled.y = v.y / s;
        return scaled;
    }
    public static Vector operator +(Vector v, Vector s)
    {
        Vector r = new Vector();

        r.x = v.x + s.x; // формула сложения двух векторов для получения другого вектора направления.
        r.y = v.y + s.y;
        return r;
    }
    public static Vector operator -(Vector v, Vector s)
    {
        //Vector r = new Vector();

        //r.x = v.x - s.x;
        //r.y = v.y - s.y;
        return new Vector(v.x - s.x, v.y - s.y); // укороченая версия operator+
    }
}

public class Point
{
    public Point() { }
    public float x, y;
    public Point(float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }

    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    Point p = new Point(); // указывем точку одного обьекта
    Point i = new Point(); // указывем точку второго обьекта
    Point c = new Point(); // указывем точку второго обьекта

    void Start()
    {
        Vector r = new Vector(4,0);
        Vector d = new Vector(0, -5);

        Vector v = r + d;
        print("new velocity: " + v.x + "," + v.y);
    }
}
*/
#endregion

#region 8-й урок Math for Game Developers - Backstabbing (Dot Product)
/*
public class Vector
{
    public Vector() { }
    public float x, y;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length(); // формула для normalized 
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; // формула для увелечения длины вектора путем умножения.
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; // формула для уменьшения длины вектора путем деления.
        scaled.y = v.y / s;
        return scaled;
    }
    public static Vector operator +(Vector v, Vector s)
    {
        Vector r = new Vector();

        r.x = v.x + s.x; // формула сложения двух векторов для получения другого вектора направления.
        r.y = v.y + s.y;
        return r;
    }
    public static Vector operator -(Vector v, Vector s)
    {
        //Vector r = new Vector();

        //r.x = v.x - s.x;
        //r.y = v.y - s.y;
        return new Vector(v.x - s.x, v.y - s.y); // укороченая версия operator+
    }
}

public class Point
{
    public Point() { }
    public float x, y;
    public Point(float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }

    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class GameMath : MonoBehaviour
{
    
    private void Start()
    {
        Vector b = new Vector(1, 0);
        Vector r = new Vector(-0.5f, 0); // скалярное произведение будет равняться -0.5

        Vector br = b - r; // это мы узнаем направление взгляда r игрока
        br.Normalized();
        print(" " + br.x + "," + br.y); // 1.5, 0;
        print(DotProduct(b, r).ToString());
    }

    public float DotProduct(Vector v, Vector s)
    {
        return v.x * s.x + v.y * s.y; // формула исчесления скалярного произведения.
    }
}
*/
#endregion

#region 9-й урок Math for Game Developers - Jumping and Gravity (Time Delta, Game Loop)
/*
public class GameMath : MonoBehaviour
{
    
    // если что см Platformer M13
    GameObject mario;
    Vector2 velocity;

    private void Start()
    {
        mario.transform.position = new Vector2(0, 0);
        mario.velocity = new Vector2(2, 2);
        mario.gravity = new Vector2(0, -2);

        float flPreviousTime = 0; // преведущий кадр
        float flCurrentTime = GetCurrentTime(); // текущий кадр

        while(true) // запускаем цикл обновления кадра (если понадобиться см скрипт Update в этом проекте).
        {
            float dt = flCurrentTime - flPreviousTime; // формула расчета DeltaTime

            if (dt > 0.15f)
                dt = 0.15f; // устанавливаем фиксед дельта тайм

            Update(dt);
        }
    }

    private void Update(float dt)
    {
        mario.position = mario.position + mario.velocity * dt; // формула расчета движения по вектору (velocity)
        mario.velocity = mario.velocity + mario.gravity * dt;  // формула расчета гравитации
    }
}
*/
#endregion

#region 10-й урок Math for Game Developers - Smooth Move(ment) (Linear Interpolation)
/*
public class GameMath : MonoBehaviour
{
    
    float Approach (float flGoal, float flCurrent, float dt)
    {
        // смотреть Platformer M13 Math.SmoothDamp
        // для использования этого метода нужно установить игровому обьекту по всем осям кординат Approach с максимальной скоростью и текущей, и установить время.
        float flDifference = flGoal - flCurrent; // вычесляем разницу между текущей и финальной скоростью.

        if (flDifference > dt)
            return flCurrent + dt;
        if (flDifference < -dt)
            return flCurrent - dt;

        return flGoal;
    }
    
}
*/
#endregion

#region 11-й урок Math for Game Developers - Mouse Control (Euler Angles)
/*
public class GameMath : MonoBehaviour
{
    // примерное использование передвижение мыши по эллеру
    public void MouseMotion(int x, int y)
    {
        int iMouseMovedX = x - lastmouseposX;
        int iMouseMovedY = y - lastmouseposY;

        float flSensitivity = 0.01f;
        player.angView.p += iMouseMovedY * flSensitivity;
        player.angView.y += iMouseMovedX * flSensitivity;

        player.angView.Normalized();
    }
}
public class Vector
{
    public Vector() { }
    public float x, y;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); // формула для получения длины вектора
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y; // формула для получения длины вектора в квадрате // для сравнения
        return length;
    }
    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length(); // формула для normalized 
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; // формула для увелечения длины вектора путем умножения.
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; // формула для уменьшения длины вектора путем деления.
        scaled.y = v.y / s;
        return scaled;
    }
    public static Vector operator +(Vector v, Vector s)
    {
        Vector r = new Vector();

        r.x = v.x + s.x; // формула сложения двух векторов для получения другого вектора направления.
        r.y = v.y + s.y;
        return r;
    }
    public static Vector operator -(Vector v, Vector s)
    {
        //Vector r = new Vector();

        //r.x = v.x - s.x;
        //r.y = v.y - s.y;
        return new Vector(v.x - s.x, v.y - s.y); // укороченая версия operator+
    }
}

public class Point
{
    public Point() { }
    public float x, y;
    public Point(float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }

    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class EAngle
{
    public float p, y, r;

    public EAngle()
    {
        p = y = r = 0;
    }

    public EAngle (float pith, float yaw, float roll)
    {
        p = pith;
        y = yaw;
        r = roll;
    }

    public EAngle Normalize()
    {
        EAngle ea = new EAngle();
        if(ea.p > 89)
            ea.p = 89;
        if (ea.p < -89)
            ea.p = -89;

        while (ea.y < -180)
            ea.y += 360;
        while (ea.y < 180)
            ea.y -= 360;

        return ea;
    }
    public Vector ToVector()
    {
        Vector result = new Vector();
        result.x = Mathf.Cos(y) * Mathf.Cos(p); // формула перевода углов в вектор по Эллеру
        result.y = Mathf.Sin(p); // Формула !!!
        // result.z = Mathf.Cos(y) * Mathf.Cos(p); //для z тоже самое.

        return result;
    }
}
*/
#endregion

#region 12-й урок Math for Game Developers - Character Movement 7 (Cross Product)
/*
    // этот урок для расчета направления движения в сторону взгдяда камеры. 
public class GameMath : MonoBehaviour
{
    
    Vector vecForward = box.angView.ToVector();
    vecForward.y = 0;
    vecForward.Normalize();

    Vector vecUp(0,1,0);
    Vector vecRight = vecUp.Cross(vecForward);
    
}
public class Vector
{
    public Vector() { }
    public float x, y, z;
    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public Vector(float X, float Y, float Z)
    {
        this.x = X;
        this.y = Y;
        this.z = Z;
    }

    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y); 
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y;
        return length;
    }

    public Vector Cross(Vector v)
    {
        Vector c = new Vector();
        c.x = y * v.z - z * v.y; // Формула для расчета Cross Product
        c.y = z * v.x - x * v.z;
        c.z = x * v.y - y * v.x;
        return c;
    }

    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length(); 
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s; 
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s; 
        scaled.y = v.y / s;
        return scaled;
    }
    public static Vector operator +(Vector v, Vector s)
    {
        Vector r = new Vector();

        r.x = v.x + s.x; 
        r.y = v.y + s.y;
        return r;
    }
    public static Vector operator -(Vector v, Vector s)
    {
        //Vector r = new Vector();

        //r.x = v.x - s.x;
        //r.y = v.y - s.y;
        return new Vector(v.x - s.x, v.y - s.y); // укороченая версия operator+
    }


}

public class Point
{
    public Point() { }
    public float x, y;
    public Point(float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }

    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}

public class EAngle
{
    public float p, y, r;

    public EAngle()
    {
        p = y = r = 0;
    }

    public EAngle(float pith, float yaw, float roll)
    {
        p = pith;
        y = yaw;
        r = roll;
    }

    public EAngle Normalize()
    {
        EAngle ea = new EAngle();
        if (ea.p > 89)
            ea.p = 89;
        if (ea.p < -89)
            ea.p = -89;

        while (ea.y < -180)
            ea.y += 360;
        while (ea.y < 180)
            ea.y -= 360;

        return ea;
    }
    public Vector ToVector()
    {
        Vector result = new Vector();
        result.x = Mathf.Cos(y) * Mathf.Cos(p); // формула перевода углов в вектор по Эллеру
        result.y = Mathf.Sin(p); // Формула !!!
        // result.z = Mathf.Cos(y) * Mathf.Cos(p); //для z тоже самое.

        return result;
    }
}
*/
#endregion

#region 13-й урокMath for Game Developers - Bullet Collision (Vector/AABB Intersection)
// этот урок для расчета попадания по обьекту. 
/*
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector v0 = box.vecPosition + Vector(0, 1, 0);
            Vector v1 = box.vecPosition + Vector(0, 1, 0) + box.angView.ToVector() * 100;

            Vector vecIntersection;
            if (TraceLine(v0, v1, vecIntersection)
            {
                MakePuff(vecIntersection);
            }
            else
            {
                MakeBulletTracer(v0, v1);
            }
            return true;
        }
        return false;
    }

    bool LineAABBIntersection(AABB aabbBox, Vector v0, Vector v1, Vector vecIntersection, float flFraction)
    {
        float f_low = 0;
        float f_high = 1;

        if (!ClipLine(1, aabbBox, v0, v1, f_low, f_high))
            return false;

        if (!ClipLine(2, aabbBox, v0, v1, f_low, f_high))
            return false;

        if (!ClipLine(3, aabbBox, v0, v1, f_low, f_high))
            return false;


        Vector b = v1 - v0; // формула B-> = V1 - V0;

        vecIntersection = v0 + b * f_low; // I = V0 + B->f;

        flFraction = f_low;

        return true;
    }
    bool ClipLine(int d, AABB aabbbBox, Vector v0, Vector v1, float f_low, float f_high)
    {
        float f_dim_low, f_dim_high;

        f_dim_low = (aabbbBox.vecMin.v(d) - v0.v(d) / (v1.v(d) - v0.v(d))); // Fy = (Py - V04)/(V1y - V04).
        f_dim_high = (aabbbBox.vecMax.v(d) - v0.v(d) / (v1.v(d) - v0.v(d)));

        if (f_dim_high < f_dim_low)
            Swap<float>(ref f_dim_high, ref f_dim_low); // или не ref?

        if (f_dim_high < f_low)
            return false;

        if (f_dim_low > f_high)
            return false;

        f_low = Mathf.Max(f_dim_low, f_low);
        f_high = Mathf.Min(f_dim_high, f_high);

        if (f_low > f_high)
            return false;

        return true;

    }
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    bool TraceLine (Vector v0, Vector v1, Vector vecIntersection)
    {
        float flLowestFraction = 1;
        Vector vecTestIntersection;
        float flTestFraction;

        // все обьекты в пространстве
        if (LineAABBIntersection(target1.aabbSize + target1.vecPosition, v0, v1, vecTestIntersection, flTestFraction) && flTestFraction < flLowestFraction)
        {
            vecIntersection = vecTestIntersection;
            flLowestFraction = flTestFraction;
        }

        if (LineAABBIntersection(target2.aabbSize + target2.vecPosition, v0, v1, vecTestIntersection, flTestFraction) && flTestFraction < flLowestFraction)
        {
            vecIntersection = vecTestIntersection;
            flLowestFraction = flTestFraction;
        }

        if (LineAABBIntersection(target3.aabbSize + target3.vecPosition, v0, v1, vecTestIntersection, flTestFraction) && flTestFraction < flLowestFraction)
        {
            vecIntersection = vecTestIntersection;
            flLowestFraction = flTestFraction;
        }

        if (flLowestFraction < 1)
            return true;

        return false;
    }

}

public class AABB
{
    public Vector vecMin;
    public Vector vecMax;

    public static AABB operator +(AABB a, Point p)
    {
        AABB result = new AABB();
        result.vecMin.x = p.x + result.vecMin.x; // формула Fcng Collision.
        result.vecMin.y = p.y + result.vecMin.y;
        result.vecMin.x = p.x + result.vecMin.x;
        result.vecMax.y = p.y + result.vecMax.y;
        return result;
    }
}


public class Vector
{
    public Vector() { }
    public float x, y, z;

    public Vector(float X, float Y)
    {
        this.x = X;
        this.y = Y;
    }
    public Vector(float X, float Y, float Z)
    {
        this.x = X;
        this.y = Y;
        this.z = Z;
    }

    public float Length()
    {
        float length;
        length = Mathf.Sqrt(x * x + y * y);
        return length;
    }
    public float LengthSqr()
    {
        float length;
        length = x * x + y * y;
        return length;
    }

    public Vector Cross(Vector v)
    {
        Vector c = new Vector();
        c.x = y * v.z - z * v.y; // Формула для расчета Cross Product
        c.y = z * v.x - x * v.z;
        c.z = x * v.y - y * v.x;

        return c;
    }

    public Vector Normalized()
    {
        Vector normalized = new Vector();
        normalized = (this) / Length();
        return normalized;
    }
    public static Vector operator *(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x * s;
        scaled.y = v.y * s;
        return scaled;
    }
    public static Vector operator /(Vector v, float s)
    {
        Vector scaled = new Vector();
        scaled.x = v.x / s;
        scaled.y = v.y / s;
        return scaled;
    }
    public static Vector operator +(Vector v, Vector s)
    {
        Vector r = new Vector();

        r.x = v.x + s.x;
        r.y = v.y + s.y;
        return r;
    }
    public static Vector operator -(Vector v, Vector s)
    {
        //Vector r = new Vector();

        //r.x = v.x - s.x;
        //r.y = v.y - s.y;
        return new Vector(v.x - s.x, v.y - s.y); // укороченая версия operator+
    }

    public float v(int s)
    {
        switch (s)
        {
            case 0:
            default:
                break;
            case 1:
                return x;
                break;
            case 2:
                return y;
                break;
            case 3:
                return z;
                break;
        }
        return 0;
    }
}

public class Point
{
    public Point() { }
    public float x, y;
    public Point(float X, float Y)
    {
        this.x = x;
        this.y = Y;
    }

    public Point AddVector(Vector v)
    {
        Point p = new Point();
        //p.x = this.x;
        //p.y = this.y;
        p.x = x + v.x; // прибавляем вектор текущей позиции к позиции вектора.
        p.y = y + v.y; // прибавляем вектор текущей позиции к позиции вектора.
        return p;
    }

    public static Vector operator -(Point a, Point b)
    {
        Vector v = new Vector();
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }
}
*/
#endregion

#region 14-й урок Math for Game Developers - Explosions! (The Remap Function)
/*
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        float flTimeCreated = 10f; // время  создания
        float flTimeOver = 4f;   // время удаления
        float flStartSize = 0.2f; // начальный размер
        float flEndSize = 0.5f; // конечный размер
        float flSize = Remap(Time.deltaTime, flTimeCreated, flTimeOver, flStartSize, flEndSize); //(более раскрыта lerp(interpolation)) формула для изменеия размера взависимости от времени.
        // можно использовать для чего угодно Lerp короче.
    }

    float Approach (float flGoal, float flCurrent, float dt)
    {
        // смотреть Platformer M13 Math.SmoothDamp
        // для использования этого метода нужно установить игровому обьекту по всем осям кординат Approach с максимальной скоростью и текущей, и установить время.
        float flDifference = flGoal - flCurrent; // вычесляем разницу между текущей и финальной скоростью.

        if (flDifference > dt)
            return flCurrent + dt;
        if (flDifference < -dt)
            return flCurrent - dt;

        return flGoal;
    }

    float Remap (float x, float t1, float t2, float s1, float s2)
    {
        float yellow = (x - t1) / (t2 - t1); // формула Remap yellow

        float greeen = yellow * (s2 - s1) + s1; // формула Remap yellow

        return greeen;
    }
}
*/
#endregion

#region 15-й урок Math for Game Developers - Billboarding (Basis Vectors)
/*
public class GameMath : MonoBehaviour
{
    // см lookCameraSprite. // вообще см в google billboarding unity
    private void RenderBilboard(Sprite size_t, float flRadius, Vector3 vecUp, Vector3 vecRight)
    {
        vecUp = vecUp * flRadius;
        vecRight = vecRight * flRadius;

        BindTexture(iTexture);

        BeginRenderTriFan();

        TexCoord(0.0f, 0.0f); // кординаты текстуры.
        Vertex(-vecUp - vecRight); // вершины текстуры.

        TexCoord(1.0f, 0.0f);
        Vertex(-vecUp + vecRight);

        TexCoord(1.0f, 1.0f);
        Vertex(vecUp + vecRight);

        TexCoord(0.0f, 1.0f);
        Vertex(vecUp - vecRight);

        EndRender();
    }
}
*/
#endregion

#region 16-й урок Math for Game Developers - Character Movement 8 (Matrices)
/*
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        GameObject c;
        Matrix4x4 mPlayer;
        c.transform.Translate(box.vecPosition);
        c.transform(mPlayer);
    }
}
*/
#endregion

#region 17-й урок Math for Game Developers - Big Boss Enemy (Matrix Scaling)
/*
public class GameMath : MonoBehaviour
{
    // https://forum.unity3d.com/proxy.php?image=http%3A%2F%2Fwww.songho.ca%2Fopengl%2Ffiles%2Fgl_anglestoaxes01.png&hash=95c7816387bca5c62af5b4247019d077
    // если забуду https://forum.unity3d.com/threads/how-to-assign-matrix4x4-to-transform.121966/
    private void Start()
    {
        float Multipiller = 2;

        Vector3 vecXBasics = new Vector3(1, 0, 0);
        Vector3 vecYBasics = new Vector3(0, 1, 0);
        Vector3 vecZBasics = new Vector3(0, 0, 1);
        Matrix4x4 mBossMatrix = Matrix4x4.TRS(transform.position, Quaternion.identity, (vecXBasics + vecYBasics + vecZBasics) * Multipiller);
        var scale1 = ExtractScaleFromMatrix(mBossMatrix);
        var scale2 = GetScale(mBossMatrix);

        transform.localScale = scale1;

        print(string.Format("scale1: {0} \nscale2: {1}", scale1, scale2));
    }
    // получаем размер из матрицы
    public static Vector3 ExtractScaleFromMatrix(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
    // второй пример
    public static Vector3 GetScale(Matrix4x4 m)
    {
        var x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
        var y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
        var z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);

        return new Vector3(x, y, z);
    }
}
*/
#endregion

#region 18-й урок Math for Game Developers - Rotating Characters (Matrix Rotation)
/*
public class GameMath : MonoBehaviour
{
    // https://forum.unity3d.com/proxy.php?image=http%3A%2F%2Fwww.songho.ca%2Fopengl%2Ffiles%2Fgl_anglestoaxes01.png&hash=95c7816387bca5c62af5b4247019d077
    // если забуду про Matrix https://forum.unity3d.com/threads/how-to-assign-matrix4x4-to-transform.121966/
    private void Update()
    {
        float flTime = Time.deltaTime * 10;
        Vector3 vecRotateX = new Vector3(Mathf.Cos(flTime),0, Mathf.Sin(flTime)); // переменные для матрицы см 19 Math Game Dev
        Vector3 vecRotateY = new Vector3(0, 1, 0);
        Vector3 vecRotateZ = new Vector3(-Mathf.Sin(flTime), 0, Mathf.Cos(flTime));

        Matrix4x4 mRotation = Matrix4x4.TRS(transform.position, Quaternion.Euler(vecRotateX + vecRotateY + vecRotateZ), Vector3.zero);

        transform.rotation = Quaternion.Slerp(transform.rotation, QuaternionFromMatrix(mRotation), 5 * Time.deltaTime);
    }

    IEnumerator Rotate(float duration)
    {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right); //or transform.right if you want it to be locally based
            yield return null;
        }
        transform.rotation = startRot;
    }

    // получаем размер из матрицы
    public static Vector3 ExtractScaleFromMatrix(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
    // второй пример
    public static Vector3 GetScale(Matrix4x4 m)
    {
        var x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
        var y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
        var z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);

        return new Vector3(x, y, z);
    }

    public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
    {
        // Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
        q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
        q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
        q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
        return q;
    }
*/
#endregion

#region Test CrossProduct Vector3.Cross
/*
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        Vector3 right = Vector3.right;
        Vector3 forwad = Vector3.forward;
        Vector3 crossUp = Vector3.Cross(forwad, right);
        print(string.Format("right: {0} \forwad: {1} \ncrossUp: {2}", right, forwad, crossUp));
    }
}
*/
#endregion

#region 19-й урок Math for Game Developers - Character Movement 9 (Matrix Translation)
/*
public class GameMath : MonoBehaviour
{
    
    Matrix4x4 mTransform;
    Vector3 positon;
    Vector3 positon2;
    Vector3 crossProduct;
    Quaternion rotate;
    Vector3 size;
    // то есть в матрицах можно хранить передвижение повороты размер обьекта и прочие изменения векторов обьекта.
    private void Start()
    {
        positon = Vector3.right;
        positon2 = Vector3.up;
        crossProduct = Vector3.Cross(positon, positon2);
        rotate = Quaternion.identity;
        size = new Vector3(1, 1, 1) * 1.5f;
        transform.position = Vector3.zero;
        mTransform = Matrix4x4.TRS(crossProduct, rotate, size);
        Debug.Log(Cross(positon, positon2).ToString());
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, ExtractPosition(mTransform), Time.deltaTime * .5f);
        transform.localScale = Vector3.Slerp(transform.localScale, ExtractScale(mTransform), Time.deltaTime * .5f);
    }

    public static Vector3 PositionFromMatrix(Matrix4x4 m)
    {
        return m.GetColumn(3);
    }
    public static Vector3 ExtractPosition(Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }
    public static Vector3 ExtractScale(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
    public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
    {
        // Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
        q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
        q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
        q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
        return q;
    }

    public Vector3 Cross(Vector3 a, Vector3 b) // наш кросс продукт
    {
        Vector3 c = new Vector3();
        c.x = a.y * b.z - a.z * b.y; // Формула для расчета Cross Product
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;
        return c;
    }
}
*/
#endregion

#region 20-й урок Math for Game Developers - Prop Positioning (TRS Matrices)
/*
public class GameMath : MonoBehaviour
{
    // изменяем размер, перемещаем и поворачиваем с помощью матрицы TRS (Translate, Rotate, Scale);
    Matrix4x4 mTransform;
    Vector3 positon;
    Vector3 positon2;
    Vector3 crossProduct;
    Quaternion rotate;
    Vector3 size;
    // то есть в матрицах можно хранить передвижение повороты размер обьекта и прочие изменения векторов обьекта.
    private void Start()
    {
        positon = Vector3.forward;
        positon2 = Vector3.right;
        crossProduct = Vector3.Cross(positon, positon2);
        rotate = Quaternion.Euler(0, 90, 0);
        size = new Vector3(1, 1, 1) * 1.5f;
        transform.position = Vector3.zero;
        mTransform = Matrix4x4.TRS(crossProduct, rotate, size); // вот она
        Debug.Log(Cross(positon, positon2).ToString());
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, ExtractPosition(mTransform), Time.deltaTime * .5f);
        transform.localScale = Vector3.Slerp(transform.localScale, ExtractScale(mTransform), Time.deltaTime * .5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, ExtractQuaternion(mTransform), Time.deltaTime * .5f);
    }

    public static Vector3 PositionFromMatrix(Matrix4x4 m)
    {
        return m.GetColumn(3);
    }
    public static Vector3 ExtractPosition(Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }
    public static Vector3 ExtractScale(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
    public static Quaternion ExtractQuaternion(Matrix4x4 m)
    {
        // Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
        q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
        q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
        q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
        return q;
    }

    public Vector3 Cross(Vector3 a, Vector3 b) // наш кросс продукт
    {
        Vector3 c = new Vector3();
        c.x = a.y * b.z - a.z * b.y; // Формула для расчета Cross Product
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;
        return c;
    }
}
*/
#endregion

#region 21-й урок Math for Game Developers - Updated Bullet Collisions (Coordinate Systems)
/*
// инверсия спомощью unity и спомощью формул
public class GameMath : MonoBehaviour
{
    // изменяем размер, перемещаем и поворачиваем с помощью матрицы TRS (Translate, Rotate, Scale);
    Matrix4x4 translate;
    Matrix4x4 inverseTranslate;
    Matrix4x4 rotate;
    Matrix4x4 inverseRotate;
    Matrix4x4 size;
    Matrix4x4 inverseSize;
    Matrix4x4 transform;
    Matrix4x4 inverseTransform;
    Vector3 positon;
    Vector3 positon2;
    Vector3 crossProduct;
    //Quaternion rotate;
    //Vector3 size;
    // то есть в матрицах можно хранить передвижение повороты размер обьекта и прочие изменения векторов обьекта.
    private void Start()
    {
        positon = Vector3.forward;
        positon2 = Vector3.right;
        crossProduct = Vector3.Cross(positon, positon2);
        translate = Matrix4x4.Translate(crossProduct);
        inverseTranslate = Matrix4x4.Translate(-crossProduct); // - Vector
        rotate = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 90, 0), Vector3.one);
        inverseRotate = Matrix4x4.Transpose(rotate); // Transpose
        size = Matrix4x4.Scale(new Vector3(1, 1, 1) * 1.5f);
        inverseSize = Matrix4x4.Inverse(size); // 1/size
        transform = translate * rotate * size; // m = T*R*S;
        inverseTransform = inverseSize * inverseRotate * inverseTranslate; // формула инверсии m-1 = S-1*R-1*T-1;
        //rotate = Quaternion.Euler(0, 90, 0);
        //size = new Vector3(1, 1, 1) * 1.5f;
        //transform.position = Vector3.zero;
        //mTransform = Matrix4x4.TRS(crossProduct, rotate, size);
        //mTransform = mTransform.inverse; // вот инверсия для unity(изи);
        Debug.Log("Not Inverse: " + transform.ToString());
        Debug.Log("Inverse" + inverseTransform.ToString());
    }
    private void FixedUpdate()
    {
        //transform.position = Vector3.Slerp(transform.position, ExtractPosition(mTransform), Time.deltaTime * .5f);
        //transform.localScale = Vector3.Slerp(transform.localScale, ExtractScale(mTransform), Time.deltaTime * .5f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, ExtractQuaternion(mTransform), Time.deltaTime * .5f);
    }

    public static Vector3 PositionFromMatrix(Matrix4x4 m)
    {
        return m.GetColumn(3);
    }
    public static Vector3 ExtractPosition(Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }
    public static Vector3 ExtractScale(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
    public static Quaternion ExtractQuaternion(Matrix4x4 m)
    {
        // Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
        q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
        q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
        q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
        return q;
    }

    public Vector3 Cross(Vector3 a, Vector3 b) // наш кросс продукт
    {
        Vector3 c = new Vector3();
        c.x = a.y * b.z - a.z * b.y; // Формула для расчета Cross Product
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;
        return c;
    }
}
*/
#endregion

#region 22-й урок Math for Game Developers - Bullet Collision Part 3 (Line/Plane Intersection)
/*
public class GameMath : MonoBehaviour
{
   // код расчета попадания снаряда на площадку
   bool LinePlaneIntersection(Vector3 n, Vector3 c, Vector3 x0, Vector3 x1, Vector3 vecIntersection, float flFraction)
    {
        // n = plane normal
        // c = any point in the plane
        // x0 = the beginning of our line
        // x1 = the end of our line

        Vector3 v = x1 - x0;
        Vector3 w = c - x0;

        float k = Vector3.Dot(w, n) / Vector3.Dot(v, n); // формула scalera k

        vecIntersection = x0 + k * v;
        flFraction = k;

        return k >= 0 && k <= 1; // делаем истиным если k больше 0 и меньше 1.
    }
}
*/
#endregion

#region 23-й урок Code for Game Developers - Adding and Removing Characters (Entity List)
/*
public class GameMath : MonoBehaviour
{
    // список игровых обьектов с уникальными номерами друг для друга
    private void Start()
    {
        // Обычные коллекции List/Dictonary и Arrays и т.д
        Debug.Log(gameObject.GetInstanceID().ToString());
    }
}
*/
#endregion

#region 24-й урок Math for Game Developers - Frustum Culling
/*
public class GameMath : MonoBehaviour
{
    // original Frustum class defined by six planes enclosing the frustum. The normals face inward.
    // пример риализации ненужной Frustum Culling
    bool CFrustum(Vector3 vecCenter, float flRadius)
    {
        for (int i = 0; i < 6; i++)
        {
            if (Vector3.Dot(p[i], n) + p[i].d + flRadius) <= 0) // если отрицат то не отображается и наоборот // Формула P.n + d + r
                return false;
        }
    }
        return true;
    }
*/
#endregion

#region 25-й урок Math for Game Developers - Axis-Angle Rotation
/*
public class GameMath : MonoBehaviour
{
    
    private void Update()
    {
        // как я понял можно использовать поворот Эйлера указывая x,y,z здесь все тоже самое только указываем угол поворота и ось как в эйлера т.е x-наклон, y-поворот, z-крен.
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.AngleAxis(90, Vector3.up),Time.deltaTime * 10f); 
    }
    //private Vector3 RotateVectorAroundAxisAngle(Vector3 n, float a, Vector3 v)
    //{
    //    // а это наш градус тета (градус угла);
    //    return v * cos(a) + (v.Dot(n) * n * (1 - cos(a)) + (n.Cross(n) * sin(a));// формула с С++
    //}
    
}
*/
#endregion

#region 26-й урок Math for Game Developers - Rotation Quaternions
/*
// построение Quaternion
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        Quaternions quat0 = new Quaternions(Vector3.right, 0);
        Quaternions quat90 = new Quaternions(Vector3.right, 90);
        Quaternions quat180 = new Quaternions(Vector3.right, 180);

        Quaternions quatup0 = new Quaternions(Vector3.up, 0);
        Quaternions quatup90 = new Quaternions(Vector3.up, 90);
        Quaternions quatup180 = new Quaternions(Vector3.up, 180);
        print(string.Format("{0}{1}{2}{3}{4}{5}", quat0.w, quat90.Inverted().x, quat180, quatup0, quatup90.y, quatup180.y));
        //Quaternion.Inverse;// Quaternion inverse in Unity/
    }
}

public class Quaternions
{
    public float w, x, y, z;

    public Quaternions() { }
    
    public Quaternions(Vector3 n, float a)
    {
        // a will be our theta
        // We must convert degrees to radians. (This step wasn't show in the video.)
        // 360 degrees == 2pi radians
        a = Mathf.Deg2Rad;
        w = Mathf.Cos(a / 2);
        x = n.x * Mathf.Sin(a / 2);
        y = n.y * Mathf.Sin(a / 2);
        z = n.z * Mathf.Sin(a / 2);
    }
    
    public Quaternions Inverted ()
    {
        // пример риализайции инверсии Quaternions
        Quaternions q = new Quaternions();
        q.w = w;
        q.x = -x;
        q.y = -y;
        q.z = -z;
        return q; 
    }
}
*/
#endregion

#region 27-й урок Math for Game Developers - Quaternions and Vectors
/*
// построение Quaternion
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        Quaternions q1 = new Quaternions(Vector3.up, 90);
        Quaternions q2 = new Quaternions(Vector3.right, 45);
        Quaternions q3 = q1 * q2; // the first rotation should go last
        print(string.Format("Quaternion 1: ({0}, {1}, {2}, {3})\n", q1.w, q1.v.x, q1.v.y, q1.v.z));
        print(string.Format("Quaternion 2: ({0}, {1}, {2}, {3})\n", q2.w, q2.v.x, q2.v.y, q2.v.z));
        print(string.Format("Quaternion 3, q2 * q1: ({0}, {1}, {2}, {3})\n", q3.w, q3.v.x, q3.v.y, q3.v.z));

        Vector3 vecRotated = q3 * Vector3.right;
        print(string.Format("Rotating (1, 0, 0) with q3: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));

        vecRotated = q1 * Vector3.right;
        print(string.Format("Rotating (1, 0, 0) with q1: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));

        vecRotated = q2 * vecRotated;
        print(string.Format("Rotating (0, 0, 1) with q2: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));
    }


    public class Quaternions
    {
        public float w, x, y, z;
        public Vector3 v;

        public Quaternions() { }

        public Quaternions(Vector3 n, float a)
        {
            // a will be our theta
            // We must convert degrees to radians. (This step wasn't show in the video.)
            // 360 degrees == 2pi radians
            a = Mathf.Deg2Rad; // где - то тут ошибка
            w = Mathf.Cos(a / 2);
            x = n.x * Mathf.Sin(a / 2);
            y = n.y * Mathf.Sin(a / 2);
            z = n.z * Mathf.Sin(a / 2);
            v = n * Mathf.Sin(a / 2);
        }

        public Quaternions Inverted()
        {
            // пример риализайции инверсии Quaternions
            Quaternions q = new Quaternions();
            q.w = w;
            q.x = -x;
            q.y = -y;
            q.z = -z;
            q.v = -v;
            return q;
        }

        public static Quaternions operator *(Quaternions q, Quaternions r)
        {
            Quaternions s = new Quaternions();
            s.w = r.w * q.w + Vector3.Dot(r.v, q.v);
            s.v = r.v * q.w + q.v * r.w + Vector3.Cross(r.v, q.v);
            return s;
        }
        public static Vector3 operator *(Quaternions r,Vector3 V )
        {
            Quaternions p = new Quaternions();
            p.w = 0;
            p.v = V;

            Vector3 vCV = Vector3.Cross(r.v, V);
            return V + vCV*(2*r.w) + Vector3.Cross(r.v, vCV)*2;
        }
    }
}
*/
#endregion

#region 28-й урок Math for Game Developers - Slerping Quaternions
/*
// slerp
public class GameMath : MonoBehaviour
{
    private void Start()
    {
        Quaternions q1 = new Quaternions(Vector3.up, 90);
        Quaternions q2 = new Quaternions(Vector3.right, 45);
        Quaternions q3 = q1 * q2; // the first rotation should go last
        print(string.Format("Quaternion 1: ({0}, {1}, {2}, {3})\n", q1.w, q1.v.x, q1.v.y, q1.v.z));
        print(string.Format("Quaternion 2: ({0}, {1}, {2}, {3})\n", q2.w, q2.v.x, q2.v.y, q2.v.z));
        print(string.Format("Quaternion 3, q2 * q1: ({0}, {1}, {2}, {3})\n", q3.w, q3.v.x, q3.v.y, q3.v.z));

        Vector3 vecRotated = q3 * Vector3.right;
        print(string.Format("Rotating (1, 0, 0) with q3: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));

        vecRotated = q1 * Vector3.right;
        print(string.Format("Rotating (1, 0, 0) with q1: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));

        vecRotated = q2 * vecRotated;
        print(string.Format("Rotating (0, 0, 1) with q2: ({0}, {1}, {2})\n", vecRotated.x, vecRotated.y, vecRotated.z));
    }

    public class Quaternions
    {
        public float w, x, y, z;
        public Vector3 v;

        public Quaternions() { }

        public Quaternions(Vector3 n, float a)
        {
            // a will be our theta
            // We must convert degrees to radians. (This step wasn't show in the video.)
            // 360 degrees == 2pi radians
            a = Mathf.Deg2Rad; // где - то тут ошибка
            w = Mathf.Cos(a / 2);
            x = n.x * Mathf.Sin(a / 2);
            y = n.y * Mathf.Sin(a / 2);
            z = n.z * Mathf.Sin(a / 2);
            v = n * Mathf.Sin(a / 2);
        }
        
        public static Quaternions Slerp (Quaternions other, float t)
        {
            Quaternions q = new Quaternions();
            Quaternions r = other;
            return ((r * q.Inverted()) ^ t) * q;
        }
        
        public Quaternions Inverted()
        {
            // пример риализайции инверсии Quaternions
            Quaternions q = new Quaternions();
            q.w = w;
            q.x = -x;
            q.y = -y;
            q.z = -z;
            q.v = -v;
            return q;
        }

        public static Quaternions operator *(Quaternions q, Quaternions r)
        {
            Quaternions s = new Quaternions();
            s.w = r.w * q.w + Vector3.Dot(r.v, q.v);
            s.v = r.v * q.w + q.v * r.w + Vector3.Cross(r.v, q.v);
            return s;
        }
        public static Vector3 operator *(Quaternions r,Vector3 V )
        {
            Quaternions p = new Quaternions();
            p.w = 0;
            p.v = V;

            Vector3 vCV = Vector3.Cross(r.v, V);
            return V + vCV*(2*r.w) + Vector3.Cross(r.v, vCV)*2;
        }
    }
}
*/
#endregion

#region Compare Lerp & Slerp Quaternion

// сравнение слерп и лерп в Quartanion
public class GameMath : MonoBehaviour
{
    [SerializeField] GameObject goQuatSlerp;
    [SerializeField] GameObject goQuatLerp;
    [SerializeField] GameObject goTranslateSlerp;
    [SerializeField] GameObject goTranslateLerp;
    [SerializeField] GameObject goSizeLerp;
    [SerializeField] GameObject goSizeSlerp;
    [SerializeField] GameObject goAcces;
    [SerializeField] float speed = 1.0f;
    [Header("Test")]
    //[SerializeField]
    //float acceleration;
    [SerializeField] float flGoalSpeed;
    [SerializeField] float flCurrentSpeed;
    //[SerializeField] bool lol;

    Vector3 vecLerp;
    Vector3 vecSlerp;

    private void Start(){
        vecLerp = new Vector3(goTranslateLerp.transform.localPosition.x + 3.5f, goTranslateLerp.transform.localPosition.y, goTranslateLerp.transform.localPosition.z);
        vecSlerp = new Vector3(goTranslateSlerp.transform.localPosition.x + 3.5f, goTranslateSlerp.transform.localPosition.y, goTranslateSlerp.transform.localPosition.z);
        //lol = false;
    }

    private void Update(){
        // transform.Translate(velocity * Time.deltaTime);
        goQuatLerp.transform.rotation = Quaternion.Lerp(goQuatLerp.transform.rotation, Quaternion.AngleAxis(0, Vector3.forward), Time.deltaTime * speed);
        goQuatSlerp.transform.rotation = Quaternion.Slerp(goQuatLerp.transform.rotation, Quaternion.AngleAxis(0, Vector3.forward), Time.deltaTime * speed); // потестить вектор форвард менять значение вектора.
        goTranslateSlerp.transform.position = Vector3.Slerp(goTranslateSlerp.transform.localPosition, vecSlerp, Time.deltaTime * speed);
        goTranslateLerp.transform.position = Vector3.Lerp(goTranslateLerp.transform.localPosition, vecLerp, Time.deltaTime * speed);
        goSizeLerp.transform.localScale = Vector3.Lerp(goSizeLerp.transform.localScale, Vector3.one, Time.deltaTime * speed);
        goSizeSlerp.transform.localScale = Vector3.Slerp(goSizeSlerp.transform.localScale, Vector3.one, Time.deltaTime * speed);
        

        goAcces.transform.Translate(Approach(flGoalSpeed, flCurrentSpeed, Time.deltaTime), 0, 0);

        //if (acceleration < maxSpeed && lol)
        //{
        //    acceleration += 1;
        //}
        //else if (acceleration >= maxSpeed || !lol)
        //{
        //    lol = false;
        //    acceleration -= 1;
        //    if (acceleration < 0)
        //    {
        //        acceleration = 0;
        //    }
        //}
    }

    float Approach(float flGoal, float flCurrent, float dt){
        // смотреть Platformer M13 Math.SmoothDamp
        // для использования этого метода нужно установить игровому обьекту по всем осям кординат Approach с максимальной скоростью и текущей, и установить время.
        float flDifference = flGoal - flCurrent; // вычесляем разницу между текущей и финальной скоростью.

        if (flDifference > dt)
            return flCurrent + dt;
        if (flDifference < dt)
            return flCurrent - dt;

        return flGoal;
    }
}
#endregion