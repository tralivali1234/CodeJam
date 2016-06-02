﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

using BenchmarkDotNet.Attributes;

using CodeJam.PerfTests.Configs;
using CodeJam.PerfTests.Running.Core;
using CodeJam.PerfTests.Running.Messages;

using NUnit.Framework;

using static CodeJam.PerfTests.PerfTestConfig;

namespace CodeJam.PerfTests
{
	[TestFixture(Category = "BenchmarkDotNet")]
	[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class CompetitionAnalyserAccuracyTests
	{
		private static readonly ICompetitionConfig _accurateConfig = new ManualCompetitionConfig(FastRunConfig.Instance)
		{
			DebugMode = true,
			EnableReruns = true
		};

		[Test]
		public static void TestCompetitionAnalyserTooFastBenchmark()
		{
			var summary = CompetitionBenchmarkRunner.Run<TooFastBenchmark>(_accurateConfig);
			var runState = CompetitionCore.RunState[summary];
			var messages = runState.GetMessages();
			Assert.AreEqual(summary.ValidationErrors.Length, 0);
			Assert.AreEqual(runState.RunNumber, 1);
			Assert.AreEqual(runState.RunsLeft, 0);
			Assert.AreEqual(runState.RunLimitExceeded, false);
			Assert.AreEqual(runState.LooksLikeLastRun, true);
			Assert.AreEqual(messages.Length, 1);

			Assert.AreEqual(messages[0].RunNumber, 1);
			Assert.AreEqual(messages[0].RunMessageNumber, 1);
			Assert.AreEqual(messages[0].MessageSeverity, MessageSeverity.Warning);
			Assert.AreEqual(messages[0].MessageSource, MessageSource.Analyser);
			Assert.AreEqual(
				messages[0].MessageText,
				"The benchmarks TooFast, TooFast2 run faster than 400 nanoseconds. Results cannot be trusted.");
		}

		[Test]
		public static void TestCompetitionAnalyserTooSlowBenchmark()
		{
			var summary = CompetitionBenchmarkRunner.Run<TooSlowBenchmark>(SingleRunConfig);
			var runState = CompetitionCore.RunState[summary];
			var messages = runState.GetMessages();
			Assert.AreEqual(summary.ValidationErrors.Length, 0);
			Assert.AreEqual(runState.RunNumber, 1);
			Assert.AreEqual(runState.RunsLeft, 0);
			Assert.AreEqual(runState.RunLimitExceeded, false);
			Assert.AreEqual(runState.LooksLikeLastRun, true);
			Assert.AreEqual(messages.Length, 1);

			Assert.AreEqual(messages[0].RunNumber, 1);
			Assert.AreEqual(messages[0].RunMessageNumber, 1);
			Assert.AreEqual(messages[0].MessageSeverity, MessageSeverity.Warning);
			Assert.AreEqual(messages[0].MessageSource, MessageSource.Analyser);
			Assert.AreEqual(
				messages[0].MessageText,
				"The benchmarks TooSlow run longer than 0.5 sec." +
					" Consider to rewrite the test as the peek timings will be hidden by averages" +
					" or set the AllowSlowBenchmarks to true.");
		}

		[Test]
		public static void TestCompetitionAnalyserTooSlowOk()
		{
			var overrideConfig = new ManualCompetitionConfig(SingleRunConfig)
			{
				AllowSlowBenchmarks = true
			};

			var summary = CompetitionBenchmarkRunner.Run<TooSlowBenchmark>(overrideConfig);
			var runState = CompetitionCore.RunState[summary];
			var messages = runState.GetMessages();
			Assert.AreEqual(summary.ValidationErrors.Length, 0);
			Assert.AreEqual(runState.RunNumber, 1);
			Assert.AreEqual(runState.RunsLeft, 0);
			Assert.AreEqual(runState.RunLimitExceeded, false);
			Assert.AreEqual(runState.LooksLikeLastRun, true);
			Assert.AreEqual(messages.Length, 1);

			Assert.AreEqual(messages[0].RunNumber, 1);
			Assert.AreEqual(messages[0].RunMessageNumber, 1);
			Assert.AreEqual(messages[0].MessageSeverity, MessageSeverity.Informational);
			Assert.AreEqual(messages[0].MessageSource, MessageSource.Analyser);
			Assert.AreEqual(messages[0].MessageText, "Analyser CompetitionAnnotateAnalyser: no warnings.");
		}

		[Test]
		public static void TestCompetitionAnalyserHighAccuracyBenchmark()
		{
			var stopwatch = Stopwatch.StartNew();
			var summary = CompetitionBenchmarkRunner.Run<HighAccuracyBenchmark>(_accurateConfig);
			stopwatch.Stop();
			var runState = CompetitionCore.RunState[summary];
			var messages = runState.GetMessages();
			Assert.AreEqual(runState.RunNumber, 1);
			Assert.AreEqual(runState.RunsLeft, 0);
			Assert.AreEqual(runState.RunLimitExceeded, false);
			Assert.AreEqual(runState.LooksLikeLastRun, true);
			Assert.AreEqual(messages.Length, 1);

			Assert.AreEqual(messages[0].RunNumber, 1);
			Assert.AreEqual(messages[0].RunMessageNumber, 1);
			Assert.AreEqual(messages[0].MessageSeverity, MessageSeverity.Informational);
			Assert.AreEqual(messages[0].MessageSource, MessageSource.Analyser);
			Assert.AreEqual(messages[0].MessageText, "Analyser CompetitionAnnotateAnalyser: no warnings.");
			Assert.LessOrEqual(stopwatch.Elapsed.TotalSeconds, 8, "Timeout failed");
		}

		#region Benchmark classes
		public class TooFastBenchmark
		{
			[Benchmark]
			public int TooFast()
			{
				var a = 0;
				for (var i = 0; i < 10; i++)
				{
					a = a + i;
				}
				return a;
			}

			[Benchmark]
			public int TooFast2()
			{
				var a = 0;
				for (var i = 0; i < 100; i++)
				{
					a = a + i;
				}
				return a;
			}
		}
		public class TooSlowBenchmark
		{
			[CompetitionBenchmark(DoesNotCompete = true)]
			public void TooSlow() => Thread.Sleep(550);
		}
		public class HighAccuracyBenchmark
		{
			[CompetitionBaseline]
			public void Baseline() => Thread.SpinWait(SpinCount);

			[CompetitionBenchmark(8.2, 11.8)]
			public void SlowerX10() => Thread.SpinWait(10 * SpinCount);
		}
		#endregion
	}
}