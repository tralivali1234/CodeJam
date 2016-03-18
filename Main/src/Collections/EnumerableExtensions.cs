﻿using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace CodeJam
{
	/// <summary>
	/// Extensions for <see cref="IEnumerable{T}"/>
	/// </summary>
	[PublicAPI]
	public static partial class EnumerableExtensions
	{
		/// <summary>
		/// Appends specified <paramref name="element"/> to end of the collection.
		/// </summary>
		[Pure, NotNull]
		public static IEnumerable<T> Concat<T>([NotNull] this IEnumerable<T> source, T element)
		{
			foreach (var item in source)
				yield return item;
			yield return element;
		}

		/// <summary>
		/// Appends specified <paramref name="elements"/> to end of the collection.
		/// </summary>
		[Pure, NotNull]
		public static IEnumerable<T> Concat<T>([NotNull] this IEnumerable<T> source, params T[] elements)
		{
			foreach (var item in source)
				yield return item;
			foreach (var element in elements)
				yield return element;
		}

		/// <summary>
		/// Prepends specified <paramref name="element"/> to the collection start.
		/// </summary>
		[Pure, NotNull]
		public static IEnumerable<T> Prepend<T>([NotNull] this IEnumerable<T> source, T element)
		{
			yield return element;
			foreach (var item in source)
				yield return item;
		}

		/// <summary>
		/// Prepends specified <paramref name="elements"/> to the collection start.
		/// </summary>
		[Pure, NotNull]
		public static IEnumerable<T> Prepend<T>([NotNull] this IEnumerable<T> source, params T[] elements)
		{
			foreach (var element in elements)
				yield return element;
			foreach (var item in source)
				yield return item;
		}

		/// <summary>
		/// Creates a <see cref="HashSet{T}"/> from an <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="HashSet{T}"/> from.</param>
		/// <returns>
		/// A <see cref="HashSet{T}"/> that contains elements from the input sequence.
		/// </returns>
		[Pure, NotNull]
		public static HashSet<T> ToHashSet<T>([NotNull] this IEnumerable<T> source) => new HashSet<T>(source);

		/// <summary>
		/// Creates a <see cref="HashSet{T}"/> from an <see cref="IEnumerable{T}"/> with the specified equality comparer.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="HashSet{T}"/> from.</param>
		/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use
		/// to comparing values in the set, or <c>null</c> to use tghe default implementation for the set type.</param>
		/// <returns>
		/// A <see cref="HashSet{T}"/> that contains elements from the input sequence.
		/// </returns>
		[Pure, NotNull]
		public static HashSet<T> ToHashSet<T>(
			[NotNull] this IEnumerable<T> source,
			[NotNull] IEqualityComparer<T> comparer) =>
				new HashSet<T>(source, comparer);

		/// <summary>
		/// Returns a sequence with distinct elements from the input sequence based on the specified key.
		/// </summary>
		/// <param name="source">The sequence to return distinct elements from.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <returns>
		/// An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> source,
			[NotNull] Func<TSource, TKey> keySelector) =>
				source.Distinct(new KeyEqualityComparer<TSource, TKey>(keySelector));

		/// <summary>
		/// Returns a sequence with distinct elements from the input sequence based on the specified key and key comparer.
		/// </summary>
		/// <param name="source">The sequence to return distinct elements from.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
		/// <returns>
		/// An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> source,
			[NotNull] Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer) =>
				source.Distinct(new KeyEqualityComparer<TSource, TKey>(keySelector, comparer));

		/// <summary>
		/// Produces the set difference of two sequences by using the specified key to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose elements that are not also in second will be returned.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <returns>
		/// A sequence that contains the set difference of the elements of two sequences.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector) =>
				first.Except(second, new KeyEqualityComparer<TSource, TKey>(keySelector));

		/// <summary>
		/// Produces the set difference of two sequences by using the specified key and <see cref="IEqualityComparer{T}"/> to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose elements that are not also in second will be returned.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
		/// <returns>
		/// A sequence that contains the set difference of the elements of two sequences.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer) =>
				first.Except(second, new KeyEqualityComparer<TSource, TKey>(keySelector, comparer));

		/// <summary>
		/// Produces the set intersection of two sequences by using the specified key to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in second will be returned.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in the first sequence will be returned.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <returns>
		/// A sequence that contains the elements that form the set intersection of two sequences.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> IntersectBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector) =>
				first.Intersect(second, new KeyEqualityComparer<TSource, TKey>(keySelector));

		/// <summary>
		/// Produces the set intersection of two sequences by using the specified key and <see cref="IEqualityComparer{T}"/> to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in second will be returned.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in the first sequence will be returned.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
		/// <returns>
		/// A sequence that contains the elements that form the set intersection of two sequences.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> IntersectBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer) =>
				first.Intersect(second, new KeyEqualityComparer<TSource, TKey>(keySelector, comparer));

		/// <summary>
		/// Produces the set union of two sequences by using the specified key to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <returns>
		/// An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> UnionBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector) =>
				first.Union(second, new KeyEqualityComparer<TSource, TKey>(keySelector));

		/// <summary>
		/// Produces the set union of two sequences by using the specified key and <see cref="IEqualityComparer{T}"/> to compare values.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union.</param>
		/// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
		/// <returns>
		/// An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates.
		/// </returns>
		[NotNull, Pure]
		public static IEnumerable<TSource> UnionBy<TSource, TKey>(
			[NotNull] this IEnumerable<TSource> first,
			[NotNull] IEnumerable<TSource> second,
			[NotNull] Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer) =>
				first.Union(second, new KeyEqualityComparer<TSource, TKey>(keySelector, comparer));

		/// <summary>
		/// Returns first element, or specified <paramref name="defaultValue"/>, if sequence is empty.
		/// </summary>
		[Pure]
		public static T FirstOrDefault<T>([NotNull] this IEnumerable<T> source, T defaultValue)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			foreach (var item in source)
				return item;
			return defaultValue;
		}

		/// <summary>
		/// Returns first element, or specified <paramref name="defaultValue"/>, if sequence is empty.
		/// </summary>
		[Pure]
		public static T FirstOrDefault<T>(
			[NotNull] this IEnumerable<T> source,
			T defaultValue,
			[NotNull] Func<T, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));
			foreach (var item in source)
				if (predicate(item))
					return item;
			return defaultValue;
		}
	}
}