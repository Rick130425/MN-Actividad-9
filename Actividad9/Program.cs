using Actividad9;

// Inicialización de datos (entrada y salida)
var data = new[]
{
    new double[]
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        11, 12, 13, 14, 15, 16, 17,
        18, 19, 20
    },

    new double[]
    {
        -2.4684, 56.8038, 4.8393,
        13.2878, -0.1931, -19.5771,
        55.4146, 74.4829, 62.0632,
        37.3616, 14.1876, 72.9088,
        81.5205, 120.7811, 156.3607,
        141.7361, 110.898, 129.7614,
        192.8516, 253.4778
    }
};

// Definición de funciones derivadas
var derivatives = new[]
{
    // x^2
    x => Math.Pow(x, 2),
    // sin(x)
    Math.Sin,
    // e^(x/10)
    x => Math.Exp(x / 10)
};

// Inicialización de la matriz Jacobiana
var jacobian = new double[20, 3];

// Cálculo de la matriz Jacobiana
for (var row = 0; row < 20; row++)
{
    for (var column = 0; column < 3; column++)
    {
        jacobian[row, column] = derivatives[column](data[0][row]);
    }
}

// Inicialización de una matriz extendida
var augMatrix = new double[3, 4];

// Transposición de la matriz Jacobiana
var tJacobian = Utils.Transpose(jacobian);

// Realización de productos de matrices (producto-punto) y guardado en la matriz extendida
augMatrix = Utils.CopyTo(
    Utils.DotProduct(tJacobian, jacobian),
    augMatrix);

// Realización de producto de matrices (producto-punto) entre transpuesta y datos de salida, 
// y guardada en la columna 3 de la matriz extendida
augMatrix = Utils.CopyTo(
    Utils.DotProduct(tJacobian, 
        Utils.CopyTo(data[1], new double[data[1].Length, 1])), 
    augMatrix, startColumn: 3);

// Aplicación de eliminación gaussiana
augMatrix = Utils.GaussianElimination(augMatrix);

// Impresión de resultados
Console.WriteLine($"{augMatrix[0,3]:0.####}t^2 + {augMatrix[1,3]:0.####}sin(t) + {augMatrix[2,3]:0.####}e^(t/10)");