#include <stdio.h>
#include <stdlib.h>

int main()
{
    int z;
    scanf("%d",&z);
    int storage [z][z];
    z=5;
    int path=0;
    int i,br=0,bri;
    int tru=0;
    //for(;br<5;br++){
       // while(i<5){scanf("%d",&storage[br][i]);i++;}
    //}
    int count,count_2;
    for ( count = 0; count < z; count++) {

        for ( count_2 = 0; count_2 < n; count_2++) {

            scanf("%d", &storage[count][count_2]);
        }
    }
    count=0;
    count_2=0;
    for(i=0;i<z;i++){
        while(bri!=z){
            if(storage[br][bri]==0)tru++;else break;
            bri++;
        }
        if(tru==z)path++;
        bri=0;
        tru=0;
        while(bri!=z){
            if(storage[bri][br]==0)tru++;else break;
            bri++;
        }
        if(tru==z)path++;
        bri=0;
        tru=0;
    };
    int memory[10];
    i=0;
    sw=0;
    int memorys=0;
    while(true){
        do{
            if(storage[count][count_2]==1){
                if(sw=0){memorys++;sw++;}
                count_2++;
            }else if(storage[count][count_2]==0){ sw=0;}
            i++;
            sw=0;
            count_2++;
        }while(count_2!=z)
        break;
        
    }
    printf("%d",path);
    printf("%d",memorys);

}
