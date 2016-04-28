﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using BenchmarkDotNet.NUnit;

using NUnit.Framework;

using IntOp = CodeJam.Arithmetic.Operators<int>;
using NullableDoubleOp = CodeJam.Arithmetic.Operators<double?>;

using static CodeJam.AssemblyWideConfig;

namespace CodeJam.Arithmetic
{
	[TestFixture(Category = BenchmarkConstants.BenchmarkCategory + ": Operators (generated)")]
	[CompetitionMetadata("CodeJam.Arithmetic.NumOperatorsPerfTests.generated.xml")]
	[Explicit("Server run speed not stable")]
	public class NumOperatorsPerfTests
	{
		#region UnaryMinus
		[Test]
		public void RunIntUnaryMinusCase() => CompetitionBenchmarkRunner.Run<IntUnaryMinusCase>(RunConfig);

		public class IntUnaryMinusCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int> _intUnaryMinus = IntOp.UnaryMinus;

			[CompetitionBaseline]
			public int UnaryMinusBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = -ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int UnaryMinusOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intUnaryMinus(ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region OnesComplement
		[Test]
		public void RunIntOnesComplementCase() => CompetitionBenchmarkRunner.Run<IntOnesComplementCase>(RunConfig);

		public class IntOnesComplementCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int> _intOnesComplement = IntOp.OnesComplement;

			[CompetitionBaseline]
			public int OnesComplementBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ~ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int OnesComplementOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intOnesComplement(ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Plus
		[Test]
		public void RunIntPlusCase() => CompetitionBenchmarkRunner.Run<IntPlusCase>(RunConfig);

		public class IntPlusCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intPlus = IntOp.Plus;

			[CompetitionBaseline]
			public int PlusBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] + ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int PlusOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intPlus(ValuesA[i], ValuesB[i]);
				return result;
			}
		}

		[Test]
		public void RunNullableDoublePlusCase() => CompetitionBenchmarkRunner.Run<NullableDoublePlusCase>(RunConfig);

		public class NullableDoublePlusCase : NullableDoubleOperatorsBaseCase
		{
			private readonly Func<double?, double?, double?> _doublePlus = NullableDoubleOp.Plus;

			[CompetitionBaseline]
			public double? PlusBaseline()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] + ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public double? PlusOperator()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _doublePlus(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Minus
		[Test]
		public void RunIntMinusCase() => CompetitionBenchmarkRunner.Run<IntMinusCase>(RunConfig);

		public class IntMinusCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intMinus = IntOp.Minus;

			[CompetitionBaseline]
			public int MinusBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] - ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int MinusOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intMinus(ValuesA[i], ValuesB[i]);
				return result;
			}
		}

		[Test]
		public void RunNullableDoubleMinusCase() => CompetitionBenchmarkRunner.Run<NullableDoubleMinusCase>(RunConfig);

		public class NullableDoubleMinusCase : NullableDoubleOperatorsBaseCase
		{
			private readonly Func<double?, double?, double?> _doubleMinus = NullableDoubleOp.Minus;

			[CompetitionBaseline]
			public double? MinusBaseline()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] - ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public double? MinusOperator()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _doubleMinus(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Mul
		[Test]
		public void RunIntMulCase() => CompetitionBenchmarkRunner.Run<IntMulCase>(RunConfig);

		public class IntMulCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intMul = IntOp.Mul;

			[CompetitionBaseline]
			public int MulBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] * ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int MulOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intMul(ValuesA[i], ValuesB[i]);
				return result;
			}
		}

		[Test]
		public void RunNullableDoubleMulCase() => CompetitionBenchmarkRunner.Run<NullableDoubleMulCase>(RunConfig);

		public class NullableDoubleMulCase : NullableDoubleOperatorsBaseCase
		{
			private readonly Func<double?, double?, double?> _doubleMul = NullableDoubleOp.Mul;

			[CompetitionBaseline]
			public double? MulBaseline()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] * ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public double? MulOperator()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _doubleMul(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Div
		[Test]
		public void RunIntDivCase() => CompetitionBenchmarkRunner.Run<IntDivCase>(RunConfig);

		public class IntDivCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intDiv = IntOp.Div;

			[CompetitionBaseline]
			public int DivBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] / ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int DivOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intDiv(ValuesA[i], ValuesB[i]);
				return result;
			}
		}

		[Test]
		public void RunNullableDoubleDivCase() => CompetitionBenchmarkRunner.Run<NullableDoubleDivCase>(RunConfig);

		public class NullableDoubleDivCase : NullableDoubleOperatorsBaseCase
		{
			private readonly Func<double?, double?, double?> _doubleDiv = NullableDoubleOp.Div;

			[CompetitionBaseline]
			public double? DivBaseline()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] / ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public double? DivOperator()
			{
				double? result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _doubleDiv(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Modulo
		[Test]
		public void RunIntModuloCase() => CompetitionBenchmarkRunner.Run<IntModuloCase>(RunConfig);

		public class IntModuloCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intModulo = IntOp.Modulo;

			[CompetitionBaseline]
			public int ModuloBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] % ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int ModuloOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intModulo(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region Xor
		[Test]
		public void RunIntXorCase() => CompetitionBenchmarkRunner.Run<IntXorCase>(RunConfig);

		public class IntXorCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intXor = IntOp.Xor;

			[CompetitionBaseline]
			public int XorBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] ^ ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int XorOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intXor(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region BitwiseAnd
		[Test]
		public void RunIntBitwiseAndCase() => CompetitionBenchmarkRunner.Run<IntBitwiseAndCase>(RunConfig);

		public class IntBitwiseAndCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intBitwiseAnd = IntOp.BitwiseAnd;

			[CompetitionBaseline]
			public int BitwiseAndBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] & ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int BitwiseAndOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intBitwiseAnd(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region BitwiseOr
		[Test]
		public void RunIntBitwiseOrCase() => CompetitionBenchmarkRunner.Run<IntBitwiseOrCase>(RunConfig);

		public class IntBitwiseOrCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intBitwiseOr = IntOp.BitwiseOr;

			[CompetitionBaseline]
			public int BitwiseOrBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] | ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int BitwiseOrOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intBitwiseOr(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region LeftShift
		[Test]
		public void RunIntLeftShiftCase() => CompetitionBenchmarkRunner.Run<IntLeftShiftCase>(RunConfig);

		public class IntLeftShiftCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intLeftShift = IntOp.LeftShift;

			[CompetitionBaseline]
			public int LeftShiftBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] << ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int LeftShiftOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intLeftShift(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion

		#region RightShift
		[Test]
		public void RunIntRightShiftCase() => CompetitionBenchmarkRunner.Run<IntRightShiftCase>(RunConfig);

		public class IntRightShiftCase : IntOperatorsBaseCase
		{
			private readonly Func<int, int, int> _intRightShift = IntOp.RightShift;

			[CompetitionBaseline]
			public int RightShiftBaseline()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = ValuesA[i] >> ValuesB[i];
				return result;
			}

			[CompetitionBenchmark]
			public int RightShiftOperator()
			{
				var result = 0;
				for (var i = 0; i < ValuesA.Length; i++)
					result = _intRightShift(ValuesA[i], ValuesB[i]);
				return result;
			}
		}
		#endregion
	}
}