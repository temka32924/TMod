#include <pthread.h>
#include "remod.h"
#include "jsonrpc.h"


EXTENSION(JSONRPC);

namespace remod
{
    namespace jsonrpc
    {
        VAR(jsonrpc, 0, 0, 1);
        VAR(jsonport, 8082, 0, 65535);

        vector<char*> tokens;

        //jsonauth token1
        //jsonauth token2

        pthread_t thread;

        void update()
        {

        }

        void *worker(void *vptr_args)
        {
            // init

        }

        void spaw_worker()
        {
            if (pthread_create(&thread, NULL, worker, NULL) != 0)
            {
                //return EXIT_FAILURE;
            }
        }
    }
}
