// Copyright (c) 2016-2017 Ilium VR, Inc.
// Licensed under the MIT License - https://raw.github.com/IliumVR/SimplerHidWrite/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;

namespace IliumVR.Tools.SimplerHidWrite
{
	public class RingQueue<T> : IEnumerable<T>
	{
		//private readonly object lockObject;
		private readonly T[] buffer;
		private int count;
		private int position;

		public RingQueue(int length)
		{
			//this.lockObject = new object();
			buffer = new T[length];
			count = 0;
			position = 0;
		}

		public int Count
		{
			get
			{
				return count;
			}
		}

		public void Push(T item)
		{
			if (count < buffer.Length)
				count++;

			buffer[position] = item;
			position = (position + 1) % buffer.Length;
		}

		public T Pop()
		{
			if (count == 0)
				throw new InvalidOperationException("Queue is empty");

			T ret = Peek();

			count--;
			position = (position - 1) % buffer.Length;

			return ret;
		}

		public T Peek()
		{
			if (count == 0)
				throw new InvalidOperationException("Queue is empty");

			return buffer[(position - 1) % buffer.Length];
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
			{
				yield return buffer[(position + i) % buffer.Length];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
