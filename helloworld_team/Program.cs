using System;
using System.Collections.Generic;

namespace helloworld_team
{
	class Program
	{
		static void Main(string[] args)
		{
			// 1.Rotations
			int[] array = { 1, 2, 3, 4, 5 };
			int d = 4;
			array = rotLeft(array, d);
			Console.WriteLine("array after {0} left rotations is", d);
			foreach (int i in array)
			{
				Console.Write(i + "  ");
			}

			// 2.MaximumToys
			int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
			int budget = 50;
			int max_toys_canbebrought = maximumToys(prices, budget);
			Console.WriteLine("\r\n\nMaximum toys that can be brought are {0}", max_toys_canbebrought);


			// 3.Balanced Sums
			Console.WriteLine("\r\nBalanced sums");
			List<int> arr = new List<int> { 1, 1, 4, 1, 1 };
			Console.WriteLine(balancedSums(arr));


			// 4.Missing Numbers
			Console.WriteLine("\r\nMissing Numbers");
			int[] a = { 11, 4, 11, 7, 13, 4, 12, 11, 10, 14 };
			int[] b = { 11, 4, 11, 7, 3, 7, 10, 13, 4, 8, 12, 11, 10, 14, 12 };
			int[] missingvals = missingNumbers(a, b);
			foreach (int i in missingvals)
				Console.Write(i + "  ");
			Console.WriteLine();


			Console.ReadKey(true);
		}

		static int[] rotLeft(int[] ar, int d)
		{
			int[] temp_arr = new int[ar.Length]; // created a temp array with size as that of original array
			try
			{

				for (int i = 0; i < ar.Length - d; i++) /* this for loop is for making rotations and loading them into temp array
														 this loop loads (array.length-rotations) elements into temp_arr*/
				{
					temp_arr[i] = ar[i + d];
				}
				for (int i = ar.Length - d; i < ar.Length; i++) /*this for loop is for rotating and loading the elements into temp array
																this loop loads the elements which are not shifted by first loop*/
				{
					temp_arr[i] = ar[i + d - ar.Length];
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while computing rotLeft and the exception is {0}", ex.Message);
			}
			return temp_arr;  // returning the rotated array by d rotations

		}

		static int maximumToys(int[] prices, int marksbudget)
		{
			int max_toys = 0, amount_spent = 0;  //intialising max_toys and amount_spent variables
			try
			{
				prices = sortArray(prices);   // sorting the array
				foreach (int k in prices)
				{
					amount_spent += k;        // adding each toy cost to the amount spent after purchasing each toy
					if (amount_spent < marksbudget) /* checking whether the amount_spent is less than the budget of mark, if yes then
													purchasing the toy */
						++max_toys;
					else
						break;                // otherwise mark over ran his budget
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while computing maximumToys and the error message is {0}", ex.Message);
			}
			return max_toys;      // returning max_toys that can be purchased with marks budget
		}

		static int[] sortArray(int[] arr)
		{
			int position, temp;  // intialising position to hold min value index and temp to swap values
			try
			{
				for (int i = 0; i < arr.Length - 1; i++) /* first for loop for looping all array elements and last element will be automatically sorted
														  after iteration*/

				{
					position = i;
					for (int j = i + 1; j < arr.Length; j++) /*starting from next element of position and looping till end*/
					{
						if (arr[j] < arr[position])   /*if value is less that the value at index then assign then assign it to position*/
						{
							position = j;
						}
					}
					if (position != i)  // if min value index has changed when compared to curr index swapping values
					{
						temp = arr[i];
						arr[i] = arr[position];
						arr[position] = temp;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while executing sortArray and the error is {0}", ex.Message);
			}
			return arr;   // returning array after performing selection sort
		}

		static string balancedSums(List<int> arr)
		{
			long rightsum = 0, leftsum = 0; //intialising leftsum and rightsum
			bool found = false;
			int length = arr.Count;
			try
			{
				while (length > 0)   // calculating the leftsum and rightsum for all elements
				{
					found = false;
					for (int j = 0; j < arr.Count; j++)  // for loop to calculate all the right side elements sum
					{
						rightsum += arr[j];
					}
					for (int k = 0; k < arr.Count; k++) // for loop for calculating left sum and then comparing with rightsum
					{
						rightsum -= arr[k];  // removing an element and then it will be added to leftsum  to balance the sum of left and right
						if (leftsum == rightsum) // comparing left sum and right sum and breaking from loop if such value is found
						{
							found = true;   // if such element is found
							break;
						}
						leftsum += arr[k];  // adding the element to leftsum
					}
					length--;  // decreasing the length for while condition
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occured while computing balancedsums and the error is {0}", ex.Message);
			}
			return (found == true ? "YES" : "NO"); //condition expression using found variable to return yes or no
		}

		static int[] missingNumbers(int[] arr, int[] brr)
		{
			List<int> missingnumberslist = new List<int>(); /*this list is used only to store missing numbers
															as a dynamic collection is needed to store missing numbers*/
			bool matched;
			try
			{
				int[] afreq = calFrequency(arr);          /*calculates frequency of array, (i) will have value 
															and (i+1) will have frequency of element at i */
				int[] bfreq = calFrequency(brr);
				for (int i = 0; (i + 1) < bfreq.Length; i += 2)     /*looping through original array b and checking whether
																	that element is present in missing array a*/
				{
					matched = false;
					for (int j = 0; (j + 1) < afreq.Length; j += 2)  /*looping through a array for element at index and frequency comparison*/
					{
						if (bfreq[i] == afreq[j] && bfreq[i + 1] == afreq[j + 1])   /*checking whether element is present and frequency 
																					is equal in both array a and b*/
						{
							matched = true;                        // if element is found and frequencies are equal then its match
						}
					}
					if (!matched)
						missingnumberslist.Add(bfreq[i]);       // if not match then adding it in missing numbers list
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occured while computing missingNumbers and the error message is {0}", ex.Message);
			}

			return sortArray(missingnumberslist.ToArray());
		}

		static int[] calFrequency(int[] ar)
		{
			int count;
			int[] freq = new int[ar.Length];  // freq array to set dummy frequency to all elements of ar array intially
			List<int> arvalandfreq = new List<int>();  // this list will store value and frequency of that value next to each other
			try
			{
				for (int i = 0; i < freq.Length; i++) //loop to assign dummy frequency for all elements intially
				{
					freq[i] = -1;
				}
				for (int i = 0; i < ar.Length; i++)  // taking each element 
				{
					count = 1;                      // every variable will have frequency >= 1
					for (int j = i + 1; j < ar.Length; j++)  // comparing that element with all other remaining elements of array
					{
						if (ar[i] == ar[j])       // if element found assigning its frequency to 0 and increasing the count by 1
						{
							freq[j] = 0;
							count++;
						}
					}
					if (freq[i] != 0)     // if frequency!=0 adding the element and its frequency to list
					{
						arvalandfreq.Add(ar[i]);   //adding element
						arvalandfreq.Add(count);   // adding frequency of that element
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occured while computing calFrequency and the error message is {0}", ex.Message);
			}
			return arvalandfreq.ToArray();  // converting the list to array and returning
		}
	}
}
