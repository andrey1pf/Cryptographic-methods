/*#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

struct Average {
	int count;
	int* array;
	double result;
};

struct MinMax {
	int count;
	int* array;
	int result_min;
	int result_max;
};

DWORD WINAPI average(LPVOID lpParam) {
	struct Average* data = (struct Average*)lpParam;

	int sum = 0;
	for (int i = 0; i < data->count; ++i) {
		sum += data->array[i];
		Sleep(12);
	}
	data->result = (double)sum / data->count;

	printf("%s\n", "average stopped");

	return 0;
}

DWORD WINAPI min_max(LPVOID lpParam) {
	struct MinMax* data = (struct MinMax*)lpParam;
	data->result_min = INT_MAX;
	data->result_max = INT_MIN;

	for (int i = 0; i < data->count; ++i) {
		if (data->array[i] < data->result_min) {
			data->result_min = data->array[i];
		}
		if (data->array[i] > data->result_max) {
			data->result_max = data->array[i];
		}
		Sleep(7);
	}

	printf("%s\n", "min_max stopped");
	printf("-----------------------------------------\n");
	return 0;
}

int main() {

	printf("enter size and number of array elements\n");
	int array_size;
	scanf_s("%d", &array_size);

	printf("-----------------------------------------\n");

	int* numbers = malloc(sizeof(int) * array_size);
	if (numbers == NULL) {
		fprintf(stderr, "Couldn't allocate array");
		ExitProcess(1);
	}

	for (int i = 0; i < array_size; ++i) {
		scanf_s("%d", &numbers[i]);
	}

	struct Average average_data;
	average_data.count = array_size;
	average_data.array = numbers;

	struct MinMax min_max_data;
	min_max_data.count = array_size;
	min_max_data.array = numbers;

	HANDLE threads[2];
	DWORD min_max_thread_id, average_thread_id;

	threads[1] = CreateThread(NULL, 0, average, &average_data, 0, &average_thread_id);
	if (threads[1] == NULL) {
		fprintf(stderr, "Error starting %s thread\n", "average");
		ExitProcess(4);
	}

	threads[0] = CreateThread(NULL, 0, min_max, &min_max_data, 0, &min_max_thread_id);
	if (threads[0] == NULL) {
		fprintf(stderr, "Error starting %s thread\n", "min_max");
		ExitProcess(3);
	}

	printf("thread ids:\nmin_max: %lu\naverage: %lu\n", min_max_thread_id, average_thread_id);
	printf("-----------------------------------------\n");

	WaitForMultipleObjects(2, threads, TRUE, INFINITE);

	printf("results:\nmin: %d\nmax: %d\naverage: %lf\n", min_max_data.result_min, min_max_data.result_max, average_data.result);
	printf("-----------------------------------------\n");
}*/

using System.Threading;
using System;
using System.Numerics;
using System.Xml;

namespace ConsoleApp1
{
	class Program
	{
		static void Main()
		{
			
		}
	}
}