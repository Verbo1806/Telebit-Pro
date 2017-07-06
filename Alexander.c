#include <stdio.h>

int main()
{
    int n, free_path = 0, types = 0;
    
    do {
        
        scanf("%d", &n);
    
    }while(n > 100 || n < 1);
    
    int warehouse[n][n], count, count_2;
    
    for (count = 0; count < n; count++) {
     
        for (count_2 = 0; count_2 < n; count_2++) {
            
            scanf("%d", &warehouse[count][count_2]);
        }
    }
    
    
    //horizontal
    for (count = 0; count < n; count++) {
        
        for (count_2 = 0; count_2 < n; count_2++) {
            
            if (warehouse[count][count_2] == 1)
                break;
                
            if (count_2 == n - 1) {
                free_path++;
            }
        }
    }

    
    //vertical
    for (count = 0; count < n; count++) {
        
        for (count_2 = 0; count_2 < n; count_2++) {
            
            if (warehouse[count_2][count] == 1)
                break;
                
            if (count_2 == n - 1)
                free_path++;
        }
    }
    
   for (count = 0; count < n; count++)
    {
        for (count_2 = 0; count_2 < n; count_2++)
        {

            if (warehouse[count][count_2] == 1)
            {
                if ((count == 0 || warehouse[count - 1][count_2] == 0) &&
                    (count_2 == 0 || warehouse[count][count_2 - 1] == 0))
                    types++;
            }
        }
    }
    

    
    printf("%d ", types);
    printf("%d", free_path);

    return 0;
}

