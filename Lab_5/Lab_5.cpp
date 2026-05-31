#include <iostream>
#include <cmath>
#include <windows.h>
#include <locale>
using namespace std;

class TRTriangle {
protected:
    double a, b, c;
    

public:
    // Конструктор без параметрів
    TRTriangle() : a(1), b(1), c(1) {}

    // Конструктор з параметром
    TRTriangle(double side) {
        if (side > 0)
            a = b = c = side;
        else
            a = b = c = 1;
    }

    // Копіювання
    TRTriangle(const TRTriangle& other) {
        a = other.a;
        b = other.b;
        c = other.c;
    }

    // Ввід
    void input() {
        cout << "Введіть сторону трикутника: ";
        cin >> a;

        if (a <= 0) {
            cout << "Сторона повинна бути > 0. Встановлено 1.\n";
            a = 1;
        }

        b = c = a;
    }

    // Вивід
    void output() const {
        cout << "Сторони: " << a << ", " << b << ", " << c << endl;
    }

    double area() const {
        return (sqrt(3) / 4) * a * a;
    }

    double perimeter() const {
        return a + b + c;
    }

    bool operator==(const TRTriangle& other) const {
        return a == other.a;
    }

    // Додавання
    TRTriangle operator+(double value) const {
        return TRTriangle(a + value);
    }

    // Віднімання
    TRTriangle operator-(double value) const {
        double newSide = a - value;
        if (newSide <= 0) {
            cout << "Результат ≤ 0, встановлено 1\n";
            newSide = 1;
        }
        return TRTriangle(newSide);
    }

    // Множення
    TRTriangle operator*(double value) const {
        return TRTriangle(a * value);
    }
};

// Похідний клас
class TPiramid : public TRTriangle {
    double height;

public:
    TPiramid() : height(1) {}

    TPiramid(double side, double h) : TRTriangle(side) {
        height = (h > 0) ? h : 1;
    }

    void input() {
        TRTriangle::input();

        cout << "Введіть висоту піраміди: ";
        cin >> height;

        if (height <= 0) {
            cout << "Помилка! Висота повинна бути > 0. Встановлено 1.\n";
            height = 1;
        }
    }

    void output() const {
        TRTriangle::output();
        cout << "Висота піраміди: " << height << endl;
    }

    double volume() const {
        return (1.0 / 3) * area() * height;
    }
};

int main() {
    SetConsoleOutputCP(65001);
    SetConsoleCP(65001);
    setlocale(LC_ALL, "uk_UA.UTF-8");

    cout << "Трикутник 1\n";
    TRTriangle t1;
    t1.input();
    t1.output();

    cout << "Площа: " << t1.area() << endl;
    cout << "Периметр: " << t1.perimeter() << endl;

    cout << "\nТрикутник 2\n";
    TRTriangle t2;
    t2.input();
    t2.output();

    if (t1 == t2)
        cout << "Трикутники рівні\n";
    else
        cout << "Трикутники не рівні\n";

    cout << "\n Операції 1 трикутника\n";

    TRTriangle t3 = t1 + 2;
    cout << "Додавання 2:\n";
    t3.output();

    TRTriangle t4 = t1 - 2;
    cout << "Віднімання 2:\n";
    t4.output();

    TRTriangle t5 = t1 * 3;
    cout << "Множення на 3:\n";
    t5.output();

    cout << "\n Піраміда \n";
    TPiramid p1;
    p1.input();
    p1.output();
    cout << "Об'єм: " << p1.volume() << endl;

    return 0;
}