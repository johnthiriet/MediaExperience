using System;
using System.Threading.Tasks;

namespace MediaExperience
{
    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static async void FireAndForgetSafeAsync<T>(this Task<T> task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
