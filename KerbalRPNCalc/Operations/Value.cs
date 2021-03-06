﻿// This file is part of KerbalRPNCalc.
// 
// KerbalRPNCalc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// KerbalRPNCalc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with KerbalRPNCalc. If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;

namespace KerbalRPNCalc.Operations
{
    internal class Value : IOperation
    {
        private readonly double _value;

        public Value(double value)
        {
            _value = value;
        }

        public Stack<double> Calculate(Stack<double> stack)
        {
            stack.Push(_value);
            return stack;
        }
    }
}