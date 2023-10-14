namespace Actividad9;

public static class Utils
{
    /// <summary>
    /// Copia los valores de una matriz en otra.
    /// </summary>
    /// <param name="src">Matriz origen.</param>
    /// <param name="destination">Matriz destino.</param>
    /// <param name="startRow">Fila inicial.</param>
    /// <param name="startColumn">Columna inicial.</param>
    /// <returns>Matriz destino con los valores copiados.</returns>
    public static double[,] CopyTo(double[,] src, double[,] destination, int startRow = 0, int startColumn = 0)
    {
        // Arreglo de dimensiones
        var size = new double[] { src.GetLength(0), src.GetLength(1) };
        for (var row = 0; row < size[0]; row++)
        {
            for (var column = 0; column < size[1]; column++)
            {
                // Se copian los valores del origen al destino, empezando desde las coordenadas dadas
                destination[row + startRow, column + startColumn] = src[row, column];
            }
        }

        // Se regresa la matriz destino con los valores copiados
        return destination;
    }

    /// <summary>
    /// Copia los valores de un arreglo a una matriz dada.
    /// </summary>
    /// <param name="array">Arreglo origen.</param>
    /// <param name="matrix">Matriz destino.</param>
    /// <param name="startRow">Fila inicial</param>
    /// <param name="startColumn">Columna inicial</param>
    /// <returns>Matriz destino con los valores copiados.</returns>
    public static double[,] CopyTo(double[] array, double[,] matrix, int startRow = 0, int startColumn = 0)
    {
        for (var row = 0; row < array.Length; row++)
        {
            // Se copian los valores del origen al destino, empezando desde las coordenadas dadas
            matrix[row + startRow, startColumn] = array[row];
        }

        // Retorno de la matriz destino con los valores copiados
        return matrix;
    }

    /// <summary>
    /// Realiza una eliminación gaussiana a la matriz introducida.
    /// </summary>
    /// <param name="augmentedMatrix">Matriz extendida.</param>
    /// <returns>Matriz resultante de la eliminación gaussiana.</returns>
    public static double[,] GaussianElimination(double[,] augmentedMatrix)
    {
        // Arreglo de dimensiones
        var size = new[] { augmentedMatrix.GetLength(0), augmentedMatrix.GetLength(1) };
        for (var pivotIndex = 0; pivotIndex < size[0]; pivotIndex++)
        {
            // Guardado del pivote
            var pivot = augmentedMatrix[pivotIndex, pivotIndex];
            for (var row = 0; row < size[0]; row++)
            {
                // Fila temporal (iniciando desde la fila del pivote)
                var tempRow = (pivotIndex + row) % size[0];
                // Si la fila es 0
                if (row == 0)
                {
                    for (var column = 0; column < size[1]; column++)
                    {
                        // División de la fila del pivote por el pivote
                        augmentedMatrix[tempRow, column] /= pivot;
                    }
                }
                // Si no
                else
                {
                    // Guardado del factor (valor de la columna del pivote en la fila)
                    var factor = augmentedMatrix[tempRow, pivotIndex];
                    for (var column = 0; column < size[1]; column++)
                    {
                        // Resta de los valores de la fila del pivote, multiplicados por el factor, a la fila actuál
                        augmentedMatrix[tempRow, column] -= augmentedMatrix[pivotIndex, column] * factor;
                    }
                }
            }
        }
        // Retorno de la matriz extendida resultante
        return augmentedMatrix;
    }
    
    /// <summary>
    /// Transpone una matriz.
    /// </summary>
    /// <param name="matrix">Matriz.</param>
    /// <returns>Transpuesta de la matriz.</returns>
    public static double[,] Transpose(double[,] matrix)
    {
        // Arreglo de dimensiones
        var size = new int[] { matrix.GetLength(0), matrix.GetLength(1) };
        // Declaración de matriz transpuesta
        var transposedMatrix = new double[size[1], size[0]];
        for (var i = 0; i < size[0]; i++)
        {
            for (var j = 0; j < size[1]; j++)
            {
                // Se invierten las coordenadas del valor y se guardan en la matriz transpuesta
                transposedMatrix[j, i] = matrix[i, j];
            }
        }
        // Retorno de la matriz transpuesta
        return transposedMatrix;
    }
    
    /// <summary>
    /// Multiplica la matriz por un coeficiente dado.
    /// </summary>
    /// <param name="coefficient">Coeficiente.</param>
    /// <param name="matrix">Matriz.</param>
    /// <returns>Matriz resultante de la multiplicación.</returns>
    public static double[,] MultMatrix(double coefficient, double[,] matrix)
    {
        // Arreglo de dimensiones
        var size = new[] { matrix.GetLength(0), matrix.GetLength(1) };
        for (var row = 0; row < size[0]; row++)
        {
            for (var column = 0; column < size[1]; column++)
            {
                // Multiplicación de valores por el coeficiente
                matrix[row, column] *= coefficient;
            }
        }
        // Retorno de la matriz multiplicada.
        return matrix;
    }
    
    /// <summary>
    /// Realiza el producto punto de dos matrices.
    /// </summary>
    /// <param name="matrixOne">Primera matriz.</param>
    /// <param name="matrixTwo">Segunda matriz.</param>
    /// <returns>Resultado del producto punto.</returns>
    public static double[,] DotProduct(double[,] matrixOne, double[,] matrixTwo)
    {
        // Declaración de la matriz resultante
        var dotProduct = new double[matrixOne.GetLength(0), matrixTwo.GetLength(1)];
        // Arreglo de dimensiones
        var measures = new double[]
        {
            dotProduct.GetLength(0),
            dotProduct.GetLength(1),
            matrixOne.GetLength(1)
        };
        for (var row = 0; row < measures[0]; row++)
        {
            for (var column = 0; column < measures[1]; column++)
            {
                for (var i = 0; i < measures[2]; i++)
                {   
                    // Sumatoria del producto de valores de matrices
                    dotProduct[row, column] += matrixOne[row, i] * matrixTwo[i, column];
                }
            }
        }
        // Retorno de la matriz resultante
        return dotProduct;
    }
}