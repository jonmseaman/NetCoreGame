namespace Engine
{
    public struct Vector2
    {
        #region Public Fields

        public int X;
        public int Y;

        #endregion

        #region Constructors

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2(int val)
        {
            X = val;
            Y = val;
        }

        #endregion

        #region Operators

        // Operators code taken and modifed from MonoGame.Vector2.
        // MIT License - Copyright (C) The Mono.Xna Team

        /// <summary>
        /// Inverts values in the specified <see cref="Vector2" />.
        /// </summary>
        /// <param name="value">Source <see cref="Vector2" /> on the right of the sub sign.</param>
        /// <returns>Result of the inversion.</returns>
        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" /> on the left of the add sign.</param>
        /// <param name="value2">Source <see cref="Vector2" /> on the right of the add sign.</param>
        /// <returns>Sum of the vectors.</returns>
        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2" /> from a <see cref="Vector2" />.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" /> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="Vector2" /> on the right of the sub sign.</param>
        /// <returns>Result of the vector subtraction.</returns>
        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        /// <summary>
        /// Multiplies the components of two vectors by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" /> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="Vector2" /> on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication.</returns>
        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }

        /// <summary>
        /// Multiplies the components of vector by a scalar.
        /// </summary>
        /// <param name="value">Source <see cref="Vector2" /> on the left of the mul sign.</param>
        /// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication with a scalar.</returns>
        public static Vector2 operator *(Vector2 value, int scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }

        /// <summary>
        /// Multiplies the components of vector by a scalar.
        /// </summary>
        /// <param name="scaleFactor">Scalar value on the left of the mul sign.</param>
        /// <param name="value">Source <see cref="Vector2" /> on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication with a scalar.</returns>
        public static Vector2 operator *(int scaleFactor, Vector2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }

        /// <summary>
        /// Divides the components of a <see cref="Vector2" /> by the components of another <see cref="Vector2" />.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" /> on the left of the div sign.</param>
        /// <param name="value2">Divisor <see cref="Vector2" /> on the right of the div sign.</param>
        /// <returns>The result of dividing the vectors.</returns>
        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }

        /// <summary>
        /// Divides the components of a <see cref="Vector2" /> by a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" /> on the left of the div sign.</param>
        /// <param name="divider">Divisor scalar on the right of the div sign.</param>
        /// <returns>The result of dividing a vector by a scalar.</returns>
        public static Vector2 operator /(Vector2 value1, int divider)
        {
            value1.X /= divider;
            value1.Y /= divider;
            return value1;
        }

        /// <summary>
        /// Compares whether two <see cref="Vector2" /> instances are equal.
        /// </summary>
        /// <param name="value1"><see cref="Vector2" /> instance on the left of the equal sign.</param>
        /// <param name="value2"><see cref="Vector2" /> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }

        /// <summary>
        /// Compares whether two <see cref="Vector2" /> instances are not equal.
        /// </summary>
        /// <param name="value1"><see cref="Vector2" /> instance on the left of the not equal sign.</param>
        /// <param name="value2"><see cref="Vector2" /> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }

        #endregion

        #region Public Methods

        // Public methods code taken from MonoGame.Vector2.
        // MIT License - Copyright (C) The Mono.Xna Team

        /// <summary>
        /// Performs vector addition on <paramref name="value1" /> and <paramref name="value2" />.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <returns>The result of the vector addition.</returns>
        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        /// <summary>
        /// Performs vector addition on <paramref name="value1" /> and
        /// <paramref name="value2" />, storing the result of the
        /// addition in <paramref name="result" />.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <param name="result">The result of the vector addition.</param>
        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="object" />.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2)
                return Equals((Vector2) obj);

            return false;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Vector2" />.
        /// </summary>
        /// <param name="other">The <see cref="Vector2" /> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Vector2" />.
        /// </summary>
        /// <returns>Hash code of this <see cref="Vector2" />.</returns>
        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();

        // ReSharper restore NonReadonlyMemberInGetHashCode

        /// <summary>
        /// Creates a new <see cref="Vector2" /> that contains subtraction of on <see cref="Vector2" /> from a another.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" />.</param>
        /// <param name="value2">Source <see cref="Vector2" />.</param>
        /// <returns>The result of the vector subtraction.</returns>
        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        /// <summary>
        /// Creates a new <see cref="Vector2" /> that contains subtraction of on <see cref="Vector2" /> from a another.
        /// </summary>
        /// <param name="value1">Source <see cref="Vector2" />.</param>
        /// <param name="value2">Source <see cref="Vector2" />.</param>
        /// <param name="result">The result of the vector subtraction as an output parameter.</param>
        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        /// <summary>
        /// Returns a <see cref="string" /> representation of this <see cref="Vector2" /> in the format:
        /// {X:[<see cref="X" />] Y:[<see cref="Y" />]}
        /// </summary>
        /// <returns>A <see cref="string" /> representation of this <see cref="Vector2" />.</returns>
        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + "}";
        }

        #endregion
    }
}